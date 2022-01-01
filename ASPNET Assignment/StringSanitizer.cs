using System.Text;
using System.Text.RegularExpressions;

namespace Databaskonstrukltion {
	public class StringSanitizer {
		private static readonly Regex m_htmlChars_Static = new Regex("<[^>]*>");

		private static bool IsNum (char c) => c >= '0' && c <= '9';

		private static bool IsLetter (char c)
		{
			return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
		}

		public static string Sanitize (string str)
		{
			if (!string.IsNullOrEmpty(str)) {
				// Cut HTML tags
				str = m_htmlChars_Static.Replace(str.Trim(), "");

				// Remove all special characters
				StringBuilder sb = new StringBuilder(str.Length);
				foreach (char c in str) {
					if (IsNum(c) || IsLetter(c)) {
						_ = sb.Append(c);
					}
				}
				return sb.ToString();
			} else {
				return str;
			}
		}
	}
}
