namespace TF.CheatsGUI.Utilities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using UnityEngine;

	internal static class ReflectionHelper
	{
		public static IEnumerable<Type> GetTypesWithAttribute<T>() where T : Attribute
		{
			return AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(asm => asm.GetTypes())
				.SelectMany(type => type.GetMethods())
				.Where(method => method.GetCustomAttributes<T>(true).Count() > 0)
				.Select(method => method.DeclaringType)
				.Distinct();
		}

		// inspired from https://stackoverflow.com/questions/607178/how-enumerate-all-classes-with-custom-class-attribute
		public static IEnumerable<Type> GetTypesWithAttribute<T>(string[] onlyAssemblies) where T : Attribute
		{
			return AppDomain.CurrentDomain.GetAssemblies()
				.Where(asm => IsContainedInOnlyAssemblies(asm, onlyAssemblies) == true)
				.SelectMany(asm => asm.GetTypes())
				.SelectMany(type => type.GetMethods())
				.Where(method => method.GetCustomAttributes<T>(true).Count() > 0)
				.Select(method => method.DeclaringType)
				.Distinct();
		}

		// inspired from http://www.java2s.com/Code/CSharp/Reflection/GetMethodsWithAttribute.htm
		public static IEnumerable<MethodInfo> GetMethodsWithAttribute(Type classType, Type attributeType)
		{
			return classType.GetMethods().Where(methodInfo => methodInfo.GetCustomAttributes(attributeType, true).Length > 0);
		}

		private static bool IsContainedInOnlyAssemblies(Assembly asm, string[] banAssembliesName)
		{
			bool doContainsAsm = Array.Exists(banAssembliesName, x => x == asm.GetName().Name);

			return doContainsAsm == true;
		}
	}
}
