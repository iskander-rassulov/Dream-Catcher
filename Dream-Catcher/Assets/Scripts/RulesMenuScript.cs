using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesMenuScript : MonoBehaviour
{
    public GameObject rulesCanvas;
    public GameObject menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);
        rulesCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton(){
        rulesCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
