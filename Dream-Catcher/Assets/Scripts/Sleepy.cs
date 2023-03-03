using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleepy : MonoBehaviour
{
    public GameObject endGameCanvas;
    private int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0){
            Time.timeScale = 0;
            endGameCanvas.SetActive(true);
        }
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BadDream"))
        {
            health = health - 10;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("GoodDream"))
        {
            health = health + 10;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            health = health - 50;
            Destroy(other.gameObject);
        }

    }
}
