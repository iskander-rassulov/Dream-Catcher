using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public PlayerController player;
    public GameObject endGameCanvas;
    public TextMeshProUGUI resultText;
    // Start is called before the first frame update
    void Start()
    {
        endGameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0){
            Properties();
        }
        //Get the value from another object's script
        int valueToDisplay = player.dreamCatched;
        resultText.text = valueToDisplay.ToString();
    }

    private void Properties(){
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartButton(){
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
