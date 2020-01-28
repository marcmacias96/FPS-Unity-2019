
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;


namespace DataBank
{
    public class GameDB : SqliteHelper
    {
        private const String tag = "Riz: LocationDb:\t";

        private const String TABLE_NAME = "Game";
        private const String KEY_IDGAME = "idGame";
        private const String KEY_TIME = "time";
        private const String KEY_LEVEL = "level";
        private const String KEY_IDPERSONA = "idPersona";
        private String[] COLUMNS = new String[] { KEY_IDGAME, KEY_TIME, KEY_LEVEL, KEY_IDPERSONA };

        public GameDB() : base()
        {
            IDbCommand dbcm = getDbCommand();
            dbcm.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                        KEY_IDGAME + " NUMERIC PRIMARY KEY, " +
                        KEY_TIME + " NUMERIC, " +
                        KEY_LEVEL + " NUMERIC, " +
                        KEY_IDPERSONA + " NUMERIC, " +
                        "FOREIGN KEY  (" + KEY_IDPERSONA + ")" +
                        "REFERENCES supplier_groups(" + KEY_IDPERSONA + ") )";

            dbcm.ExecuteNonQuery();


        }

        public void addData(GameEntity game)
        {
            IDbCommand dbcm = getDbCommand();
            dbcm.CommandText = "INSERT INTO " + TABLE_NAME
                        + " ( "
                        + KEY_IDGAME + ", "
                        + KEY_TIME + ", "
                        + KEY_IDPERSONA + ", "
                        + KEY_LEVEL + " ) "

                        + "VALUES ( "
                        + game._idGame + ", "
                        + game._time + ", "
                        + game._idPlayer + ", "
                        + game._level + ")";
            dbcm.ExecuteNonQuery();
        }

        public void UpdateByString(string str, int buenas, int malas)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "UPDATE " + TABLE_NAME
            + " SET (" + KEY_LEVEL + ","
            + KEY_IDPERSONA + ") "
            + "VALUES ( "
                        + buenas + ", "
                        + malas + " )"
            + "WHERE" + KEY_IDGAME + " = '" + str + "'";
            dbcmd.ExecuteNonQuery();
        }

        public void UpdatePositionByString(string str, int buenas, int malas)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "UPDATE " + TABLE_NAME
            + " SET (" + KEY_LEVEL + ","
            + KEY_IDPERSONA + ") "
            + " VALUES ( "
                        + buenas + "', '"
                        + malas + " ) "
            + "WHERE" + KEY_IDGAME + " = '" + str + "'";
            Debug.Log(dbcmd.CommandText);
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(tag + "Getting Location: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_IDGAME + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }


        public override void deleteDataByString(string id)
        {
            Debug.Log(tag + "Deleting Location: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_IDGAME + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            Debug.Log(tag + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }
    }
}