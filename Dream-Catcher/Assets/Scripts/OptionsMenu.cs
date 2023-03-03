using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject optionsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackButton(){
        menuCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
    }
}
