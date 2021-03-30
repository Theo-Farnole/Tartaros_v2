using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tartaros.Construction;
using UnityEngine;

namespace Tartaros
{
	public static class IConstructionRuleExtensions
	{
		public static bool DoRulesPassAtPosition(this IConstructable constructable, Vector3 buildingPosition)
		{
			if (constructable.Rules == null)
			{
				return true;
			}

			foreach (IConstructionRule rule in constructable.Rules)
			{
				if (rule == null)
				{
					Debug.LogErrorFormat("A rule is null in the constructable {0}.", constructable.ToString());
					continue;
				}

				if (rule.CanConstruct(buildingPosition) == false)
				{
					Debug.LogFormat("Rule {0} prevent construction.", rule.ToString());
					return false;
				}
			}

			return true;
		}

		public static IConstructionRule[] GetFailedRules(this IConstructable constructable, Vector3 buildingPosition)
		{
			if (constructable.Rules == null)
			{
				return null;
			}

			List<IConstructionRule> output = new List<IConstructionRule>();

			foreach (IConstructionRule rule in constructable.Rules)
			{
				if (rule == null)
				{
					Debug.LogErrorFormat("A rule is null in the constructable {0}.", constructable.ToString());
					continue;
				}

				if (rule.CanConstruct(buildingPosition) == false)
				{
					output.Add(rule);
				}
			}

			return output.ToArray(); ;
		}
	}
}
