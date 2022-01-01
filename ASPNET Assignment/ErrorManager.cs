namespace Databaskonstruktion {
	public class ErrorManager {
		private static string m_errorText_Static = null;

		internal static void WriteError (dynamic viewBag)
		{
			if (m_errorText_Static == null) {
				viewBag.HasError = false;
			} else {
				viewBag.HasError = true;
				viewBag.ErrorText = m_errorText_Static;

				ClearError();
			}
		}

		internal static void ClearError ()
		{
			m_errorText_Static = null;
		}

		internal static void SetError (string text)
		{
			m_errorText_Static = text;
		}

		internal static string GetErrorText ()
		{
			return m_errorText_Static ?? "";
		}
	}
}
