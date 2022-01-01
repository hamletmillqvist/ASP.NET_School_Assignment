using System.Data;

using MySql.Data.MySqlClient;

namespace Databaskonstruktion.Models {
	public class BannedWordsModel {
		public DataTable GetTable ()
		{
			string sql = "select Word from BannedWords";
			return SqlManager.ReadQuery(sql);
		}

		public int DeleteBannedWord (string word)
		{
			MySqlCommand sql = new MySqlCommand {
				CommandText = "delete from BannedWords where Word = @Word"
			};
			sql.Parameters.AddWithValue("@Word", word);

			return SqlManager.RunNonQuery(sql);
		}
	}
}
