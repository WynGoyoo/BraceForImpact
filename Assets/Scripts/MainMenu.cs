using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelScenetoGo;
    public string goBackMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void QuitGame()
    {
        //Para quitar el juego (solo funciona en la Build no en el editor)
        Application.Quit();

    }

    public void InGame()
    {

        SceneManager.LoadScene(levelScenetoGo);
    }

    public void InMenu()
    {

        SceneManager.LoadScene(goBackMenu);
        Time.timeScale = 1f;
    }
}
