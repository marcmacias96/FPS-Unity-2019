using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
    public class PlayerEntity 
    {
        public int _idPlayer;
        public int _health;
        public Vector3 _position;
        public int _weapons;

        public PlayerEntity(int id, int health, Vector3 pos, int weapons)
        {
            _idPlayer = id;
            _health = health;
            _position = pos;
            _weapons = weapons;
        }
    }

}

