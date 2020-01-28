using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string conecction = "URI=file:" + Application.persistentDataPath + "/My_Database";
        IDbConnection dbConnection = new SqliteConnection(conecction);
        dbConnection.Open();

        // Create table
        IDbCommand dbcmd;
        dbcmd = dbConnection.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";
        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();

        //Insert Values in Table
        IDbCommand cmnd = dbConnection.CreateCommand();
        cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES (0, 5)";
        cmnd.ExecuteNonQuery();

        //Search all data from table
        IDbCommand searchCommand = dbConnection.CreateCommand();
        IDataReader searchReader;
        searchCommand.CommandText = "SELECT * FROM my_table";
        searchReader = searchCommand.ExecuteReader();
        while (searchReader.Read())
        {
            Debug.Log("id" + searchReader[0].ToString());
            Debug.Log("Val" + searchReader[1].ToString());
        }
        dbConnection.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
