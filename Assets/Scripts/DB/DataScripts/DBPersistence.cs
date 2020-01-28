using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using DataBank;
using Mono.Data.Sqlite;
using UnityEngine;

public class DBPersistence : MonoBehaviour
{
    public TTIME time;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        initData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initData()
    {
        string conecction = "URI=file:" + Application.persistentDataPath + "/My_Database";
        IDbConnection dbConnection = new SqliteConnection(conecction);
        dbConnection.Open();

        GameDB gameDB = new GameDB();
        PlayerDB playerDB = new PlayerDB();

        //Fetch All Data
        System.Data.IDataReader readerGame = gameDB.getAllData();
        

        int fieldCount = readerGame.FieldCount;
        List<GameEntity> myGame = new List<GameEntity>();
        while (readerGame.Read())
        {
            GameEntity game = new GameEntity(Int32.Parse(readerGame[0].ToString())  ,
                                   Int32.Parse(readerGame[0].ToString()),
                                     Int32.Parse(readerGame[0].ToString()),
                                     Int32.Parse(readerGame[0].ToString()));

            Debug.Log("id: " + game._idGame);
            myGame.Add(game);
        }

        if (myGame.Count == 0)
        {
            playerDB.addData(new PlayerEntity(1, 100, playerTransform, 1));
            gameDB.addData(new GameEntity(1, time.count, 1, 1));
        }
    }


}
