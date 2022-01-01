using System.Data;

using MySql.Data.MySqlClient;

namespace Databaskonstruktion.Models {
	public class WishModel {
		public DataTable GetTable ()
		{
			return SqlManager.ReadQuery("select * from Wishlist order by Year asc;");
		}

		internal int SetAdmitted (string wishId, string wishYear, string admitStr)
		{
			MySqlCommand sql = new MySqlCommand {
				CommandText = "call AdmitWish(@wishId, @wishYear, @admit);"
			};
			sql.Parameters.AddWithValue("@wishId", wishId);
			sql.Parameters.AddWithValue("@wishYear", wishYear);
			sql.Parameters.AddWithValue("@admit", admitStr);

			return SqlManager.RunNonQuery(sql);
		}
	}
}
