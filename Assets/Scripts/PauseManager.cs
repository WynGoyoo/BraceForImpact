using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isPaused = false;

    public GameObject pausePanel;

    public GameObject endPanel;

    public GameObject hud;

    public GameObject tuto;

  

    public AudioSource pararMusic;
    public AudioSource rioMusic;
    //public GameObject mainMenu;

    public 

    



    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused == false)
        {
            if (Input.GetKeyDown("p"))
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
                tuto.SetActive(false);
                hud.SetActive(false);
                isPaused = true;
                pararMusic.enabled = false;
                rioMusic.enabled = false;





            }
        }


        else if (isPaused == true)
        {
            if (Input.GetKeyDown("p"))
            {
                Time.timeScale = 1;
                pausePanel.SetActive(false);
                tuto.SetActive(true);
                hud.SetActive(true);
                isPaused = false;
                pararMusic.enabled = true;
                rioMusic.enabled = true;

            }
        }






    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        tuto.SetActive(true);
        hud.SetActive(true);
        isPaused = false;
        

    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        tuto.SetActive(true);
        isPaused = false;
    }

    public void GameEnder()
    {

        SceneManager.LoadScene("MenuScene");
    }

    public void Pausegame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        tuto.SetActive(false);
        hud.SetActive(false);
        isPaused = true;
    }    
    
    public void EndGame()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
        tuto.SetActive(false);
        hud.SetActive(false);
        isPaused = true;
    }

    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScoreManager.Singleton.scoreCount = 0;    
    }

}
