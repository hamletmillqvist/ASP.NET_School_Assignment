using System.Data;

using MySql.Data.MySqlClient;

namespace Databaskonstruktion.Models {
	public class SleighModel {
		internal DataTable GetTable () => SqlManager.ReadQuery(
			"select Sleigh.Nr as 'Number', Sleigh.Name as 'Name', Sleigh.ManufacturerNumber as 'Manufacturer', Region.CountryName as 'Region' " +
			"from Sleigh" +
			" left join Region on Sleigh.RegionCode = Region.Code;");

		internal DataTable GetSleigh (int nr)
		{
			string sql = "select Sleigh.Nr as 'Number', Sleigh.Name as 'Name', Sleigh.ManufacturerNumber as 'Manufacturer', Region.CountryName as 'Region' from Sleigh left join Region on Sleigh.RegionCode = Region.Code where Sleigh.Nr=" + nr.ToString();

			return SqlManager.ReadQuery(sql);
		}

		internal int MoveSleigh (int sleighNr, int regionCode)
		{
			MySqlCommand sql = new MySqlCommand {
				CommandText = "call MoveSleigh(@sleighNr, @regionCode);"
			};
			sql.Parameters.AddWithValue("@sleighNr", sleighNr.ToString());
			sql.Parameters.AddWithValue("@regionCode", regionCode.ToString());

			return SqlManager.RunNonQuery(sql);
		}
	}
}
