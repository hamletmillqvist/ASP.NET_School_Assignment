using System.Data;

using MySql.Data.MySqlClient;

namespace Databaskonstruktion {
	public class SqlManager {
		public static DataTable ReadQuery (string queryString)
		{
			MySqlConnection sqlConnection = new MySqlConnection(Program.DATABASE_CONNECTION_STRING);
			sqlConnection.Open();

			MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlConnection);
			DataSet dataSet = new DataSet();

			_ = adapter.Fill(dataSet, "result");
			DataTable table = dataSet.Tables["result"];

			sqlConnection.Close();
			return table;
		}

		public static int RunNonQuery (MySqlCommand sql)
		{
			MySqlConnection sqlConnection = new MySqlConnection(Program.DATABASE_CONNECTION_STRING);
			sqlConnection.Open();
			sql.Connection = sqlConnection;

			int rowsChanged = sql.ExecuteNonQuery();
			sqlConnection.Close();

			return rowsChanged;
		}
	}
}
