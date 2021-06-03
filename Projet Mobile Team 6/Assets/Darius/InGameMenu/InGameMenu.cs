using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InGameMenu : MonoBehaviour
{
    public GameObject UIGame;
    public GameObject MenuPause;
    public GameObject DefaetMenu;
    public GameObject VictoryMenu;

    public bool loose;
    public bool win;

    private void Start()
    {
        UIGame.SetActive(true);
        MenuPause.SetActive(false);
        DefaetMenu.SetActive(false);
        VictoryMenu.SetActive(false);
    }

    private void Update()
    {
        Defaet(loose);
        Victory(win);
    }

    public void Pause()
    {
        UIGame.SetActive(false);
        MenuPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        UIGame.SetActive(true);
        MenuPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Defaet(bool Loose)
    {
        if(Loose)
        {
            DefaetMenu.SetActive(true);
            MenuPause.SetActive(false);
        }
    }

    public void Victory(bool Win)
    {
        if (Win)
        {
            VictoryMenu.SetActive(true);
            MenuPause.SetActive(false);
        }
    }

    public void Retry()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        Debug.Log("Next");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
