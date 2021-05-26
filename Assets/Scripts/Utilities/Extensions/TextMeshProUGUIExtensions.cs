namespace Tartaros
{
	using System.Collections;
	using TMPro;
	using UnityEngine;

	public static class TextMeshProUGUIExtensions
	{
		public static Coroutine SetTextAnimated(this TextMeshProUGUI text, string content, float secondsBetweenCharacter, bool useUnscaledDeltaTime)
		{
			if (text is null) throw new System.ArgumentNullException(nameof(text));

			return text.StartCoroutine(SetTextAnimated_coroutine(text, content, secondsBetweenCharacter, useUnscaledDeltaTime));
		}

		private static IEnumerator SetTextAnimated_coroutine(TextMeshProUGUI text, string content, float secondsBetweenCharacter, bool useUnscaledDeltaTime)
		{
			for (int i = 0; i < content.Length; i++)
			{
				text.text = content.Substring(0, i);

				if (useUnscaledDeltaTime == true)
				{
					yield return new WaitForSecondsRealtime(secondsBetweenCharacter);
				}
				else
				{
					yield return new WaitForSeconds(secondsBetweenCharacter);
				}
			}
		}
	}
}
