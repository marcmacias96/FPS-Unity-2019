using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
    public class PlayerEntity 
    {
        public int _idPlayer;
        public int _health;
        public Transform _position;
        public int _weapons;

        public PlayerEntity(int id, int health, Transform pos, int weapons)
        {
            _idPlayer = id;
            _health = health;
            _position = pos;
            _weapons = weapons;
        }
    }

}

