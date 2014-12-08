using System;
using System.Data;
using Mono.Data.SqliteClient;

public class DataBase {

	public string dbName = "game_db";
	private string constr= "URI=file:Assets/Database/game_db.db";
	private IDbConnection dbc;
	private IDbCommand dbcm;
	private IDataReader reader;

	private void OpenDB(){

		dbc=new SqliteConnection(constr);
		dbc.Open();
	}

	private void CloseDB(){

		reader.Close ();
		reader = null;
		dbcm.Dispose();
		dbcm = null;
		dbc.Close ();
		dbc = null;
	}

	private void ExecuteDB(string sql){

		OpenDB ();

		dbcm = dbc.CreateCommand();
		dbcm.CommandText = sql;
		reader = dbcm.ExecuteReader();

		CloseDB ();

	}

	private void ExecuteDBInsert(string sql){
		
		OpenDB ();
		
		dbcm = dbc.CreateCommand();
		dbcm.CommandText = sql;
		reader = dbcm.ExecuteReader();

	
	}

	public void DatabaseCheck(){

		ExecuteDB ("CREATE TABLE IF NOT EXISTS scene(pk  INTEGER PRIMARY KEY, playername varchar(10), scenenumber INTEGER);");

	}

	public void Insert(int scene){

		string _delete = "DELETE FROM scene;";
		string _insert = "INSERT INTO scene (pk,playername,scenenumber) VALUES (" + 1 + "," + "'default'" + "," + scene + ");";

		ExecuteDB (_delete);
		ExecuteDB (_insert);
	}

	public int SelectlastScene(){

		string sql = "SELECT * FROM scene;";
		ExecuteDBInsert (sql);
		int i;

		if (reader.Read())
						i = reader.GetInt32 (reader.GetOrdinal ("scenenumber"));
				else
						i = 0;

		CloseDB ();

		return i;
	} 


}
