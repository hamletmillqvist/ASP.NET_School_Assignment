using System.Data;

namespace Databaskonstruktion.Models {
	public class ChildModel {
		public DataTable GetTable (string searchText = null)
		{
			string sql = "select Id, concat(FirstName, ' ', LastName) as 'Full Name', YearOfBirth as 'Year of Birth' from Child";
			if (!string.IsNullOrEmpty(searchText)) {
				sql += " where concat(FirstName, ' ', LastName) like '%" + searchText + "%'";
			}
			sql += ";";

			return SqlManager.ReadQuery(sql);
		}
	}
}
