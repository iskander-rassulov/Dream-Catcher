using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject optionsCanvas;
    public GameObject rulesCanvas;

    
    private bool isMenuOpen = false;
    private bool isGamePaused = false;
    

    void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        optionsCanvas.SetActive(false);
        menuCanvas.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;

        menuCanvas.SetActive(true);

        isMenuOpen = true;
    }
    
    void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;

        optionsCanvas.SetActive(false);
        menuCanvas.SetActive(false);
        rulesCanvas.SetActive(false);

        isMenuOpen = false;
    }

    public void ExitButton(){
        Application.Quit();
    }

    public void OptionsMenu()
    {
        optionsCanvas.SetActive(true);
    }
    public void RulesMenu()
    {
        rulesCanvas.SetActive(true);
    }
}

