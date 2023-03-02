using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleepy : MonoBehaviour
{
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BadDream"))
        {
            score--;
            Debug.Log(score);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("GoodDream"))
        {
            score++;
            Debug.Log(score);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            score = score - 100;
            Debug.Log(score);
            Destroy(other.gameObject);
        }

    }
}
