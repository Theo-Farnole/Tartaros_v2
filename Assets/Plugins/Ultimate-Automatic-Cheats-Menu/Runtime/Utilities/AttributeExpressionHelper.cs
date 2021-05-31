namespace TF.CheatsGUI
{
	using System;
	using System.Reflection;
	using UnityEngine;

	internal static class AttributeExpressionHelper
	{
		private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

		public static bool IsExpressionTrue(string attributeExpression, Type type)
		{
			bool isExpressionAMethod = attributeExpression.EndsWith("()");
			bool reverseOutput = attributeExpression.Contains("!");
			bool output;

			attributeExpression = attributeExpression.Replace("!", "");

			if (isExpressionAMethod)
			{
				output = DoMethodReturnsTrue(attributeExpression, type);
			}
			else
			{
				output = DoFieldReturnsTrue(attributeExpression, type);
			}

			if (reverseOutput)
			{
				output = !output;
			}

			return output;
		}

		private static bool DoFieldReturnsTrue(string attributeExpression, Type type)
		{
			FieldInfo fieldInfo = type.GetField(attributeExpression, FLAGS);

			if (fieldInfo == null)
			{
				Debug.LogErrorFormat("Cannot find the field '{0}' of type {1}.", attributeExpression, type);
				return false;
			}

			if (fieldInfo.FieldType != typeof(bool))
				throw new NotSupportedException("AttributeExpressionHelper.GetValue only supports field that returns boolean.");

			if (fieldInfo.IsStatic == false)
				throw new NotSupportedException("AttributeExpressionHelper.GetValue only supports static fields.");

			return (bool)fieldInfo.GetValue(null);
		}

		private static bool DoMethodReturnsTrue(string attributeExpression, Type type)
		{
			string methodName = attributeExpression.Replace("()", "");
			MethodInfo methodInfo = type.GetMethod(methodName, FLAGS);

			if (methodInfo == null)
			{
				Debug.LogErrorFormat("Cannot find the method '{0}' of type {1}.", methodName, type);
				return false;
			}

			if (methodInfo.GetParameters().Length > 0)
				throw new NotSupportedException("AttributeExpressionHelper.GetValue doesn't supports method with paramaters.");

			if (methodInfo.ReturnType != typeof(bool))
				throw new NotSupportedException("AttributeExpressionHelper.GetValue only supports method that returns boolean.");

			if (methodInfo.IsStatic == false)
				throw new NotSupportedException("AttributeExpressionHelper.GetValue only supports static methods.");

			return (bool)methodInfo.Invoke(null, null);
		}
	}
}
