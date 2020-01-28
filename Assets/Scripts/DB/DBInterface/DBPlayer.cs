
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;


namespace DataBank
{
    public class PlayerDB : SqliteHelper
    {
        private const String tag = "Riz: LocationDb:\t";

        private const String TABLE_NAME = "Player";
        private const String KEY_IDPERSONA = "idPlayer";
        private const String KEY_HEALTH = "health";
        private const String KEY_WEAPONS = "weapons";
        private const String KEY_X = "x";
        private const String KEY_Y = "y";
        private const String KEY_Z = "z";
        private String[] COLUMNS = new String[] { KEY_IDPERSONA, KEY_HEALTH, KEY_WEAPONS, KEY_X, KEY_Y, KEY_Z };

        public PlayerDB() : base()
        {
            IDbCommand dbcm = getDbCommand();
            dbcm.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                        KEY_IDPERSONA + " NUMERIC PRIMARY KEY, " +
                        KEY_HEALTH + " NUMERIC, " +
                        KEY_WEAPONS + " NUMERIC, " +
                        KEY_X + " NUMERIC, " +
                        KEY_Y + " NUMERIC, " +
                        KEY_Z + " NUMERIC )";

            dbcm.ExecuteNonQuery();


        }

        public void addData(PlayerEntity player)
        {
            IDbCommand dbcm = getDbCommand();
            dbcm.CommandText = "INSERT INTO " + TABLE_NAME
                        + " ( "
                        + KEY_IDPERSONA + ", "
                        + KEY_HEALTH + ", "
                        + KEY_X + ", "
                        + KEY_Y + ", "
                        + KEY_Z + ", "
                        + KEY_WEAPONS + " ) "

                        + "VALUES ( '"
                        + player._idPlayer + "', '"
                        + player._health + "', '"
                        + player._position.x + "', '"
                        + player._position.y + "', '"
                        + player._position.z + "', '"
                        + player + "' )";
            dbcm.ExecuteNonQuery();
        }

        public void UpdateByString(string str, int buenas, int malas)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "UPDATE " + TABLE_NAME
            + " SET (" + KEY_WEAPONS + ","
            + KEY_X + ") "
            + "VALUES ( "
                        + buenas + ", "
                        + malas + " )"
            + "WHERE" + KEY_IDPERSONA + " = '" + str + "'";
            dbcmd.ExecuteNonQuery();
        }

        public void UpdatePositionByString(string str, int buenas, int malas)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "UPDATE " + TABLE_NAME
            + " SET (" + KEY_WEAPONS + ","
            + KEY_X + ") "
            + " VALUES ( "
                        + buenas + "', '"
                        + malas + " ) "
            + "WHERE" + KEY_IDPERSONA + " = '" + str + "'";
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
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_IDPERSONA + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }


        public override void deleteDataByString(string id)
        {
            Debug.Log(tag + "Deleting Location: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_IDPERSONA + " = '" + id + "'";
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