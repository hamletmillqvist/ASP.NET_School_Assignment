using System.Data;

using MySql.Data.MySqlClient;

namespace Databaskonstruktion.Models {
	public class RegionModel {
		public DataTable GetTable () => SqlManager.ReadQuery("Select * from Region;");

		public int InsertRegion (string code, string countryName, char climate)
		{
			MySqlCommand sql = new MySqlCommand {
				CommandText = "insert into Region (Code, CountryName, Climate) values (@Code, @CountryName, @Climate);"
			};
			sql.Parameters.AddWithValue("@Code", code);
			sql.Parameters.AddWithValue("@CountryName", countryName);
			sql.Parameters.AddWithValue("@Climate", climate);

			return SqlManager.RunNonQuery(sql);
		}
	}
}
