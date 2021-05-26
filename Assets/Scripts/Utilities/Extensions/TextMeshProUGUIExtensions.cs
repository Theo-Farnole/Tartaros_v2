namespace Tartaros
{
	using System.Collections;
	using TMPro;
	using UnityEngine;

	public static class TextMeshProUGUIExtensions
	{
		public static Coroutine SetTextAnimated(this TextMeshProUGUI text, string content, float secondsBetweenCharacter)
		{
			if (text is null) throw new System.ArgumentNullException(nameof(text));

			return text.StartCoroutine(SetTextAnimated_coroutine(text, content, secondsBetweenCharacter));
		}

		private static IEnumerator SetTextAnimated_coroutine(TextMeshProUGUI text, string content, float secondsBetweenCharacter)
		{
			for (int i = 0; i < content.Length; i++)
			{
				text.text = content.Substring(0, i);

				yield return new WaitForSeconds(secondsBetweenCharacter);
			}
		}
	}
}
