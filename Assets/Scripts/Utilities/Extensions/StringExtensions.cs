namespace Tartaros
{
	public static class StringExtensions
	{
		public static string Format(this string str, object arg) => string.Format(str, arg);
		public static string Format(this string str, params object[] args) => string.Format(str, args);
	}
}