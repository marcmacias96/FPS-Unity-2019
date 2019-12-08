using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public List<GameObject>  enemies;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }
}
