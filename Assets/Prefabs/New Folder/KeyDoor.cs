using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    private Animator anim;
    public Light luz;
    public List<GameObject> enemies;

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
        luz.color = Color.green;
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }

    }


}
