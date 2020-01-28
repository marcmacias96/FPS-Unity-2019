using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
    public class GameEntity 
    {
        public int _idGame;
        public float _time;
        public int _level;
        public int _idPlayer;

        public GameEntity(int id, float time, int level, int idPlayer)
        {
            _idGame = id;
            _time = time;
            _level = level;
            _idPlayer = idPlayer;
        }
    }

}

