using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TTIME : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private float time=0f;
    public float count;
    void Start()
    {
        txt.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        time += Time.deltaTime;
        txt.text = time.ToString();

        if (time >=count )
        {
            SceneManager.LoadScene("LoseScene");//StartCoroutine("Times");
        } 
          
    }


    IEnumerator Times()
    {

        
        time--;
     
        
        yield return new WaitForSeconds(1f);

    }
}
