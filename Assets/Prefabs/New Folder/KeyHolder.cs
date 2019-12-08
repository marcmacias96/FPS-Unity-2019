﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    //public Animation Animation;

    private void Awake()
    {
       // Animation = GetComponent<Animation>();
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType) {
        Debug.Log("Added key " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider other)
    {
        

        Key key = other.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);

        }


        KeyDoor keyDoor = other.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.GetKeyType())) {
                Debug.Log("si tienes la llave");
                //Animation.Play();
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();

                                             
            }

        }

        //Debug.Log(keyDoor.GetKeyType());



    }

    
}