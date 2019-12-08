using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor() {
        //gameObject.SetActive(false);
        anim.SetBool("puerta",true);
    }


}
