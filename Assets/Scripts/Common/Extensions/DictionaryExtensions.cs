namespace Tartaros
{
	using System.Collections.Generic;
	using System.Linq;

	public static class DictionaryExtensions
	{
		public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> toCloneDictionary)
		{
			Dictionary<TKey, TValue> clonedDictionary = toCloneDictionary.ToDictionary(entry => entry.Key, entry => entry.Value);
			return clonedDictionary;
		}
	}
}
