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
    AudioSource[] list;

    public bool loose;
    public bool win;

    private void Awake()
    {
        list = FindObjectsOfType<AudioSource>();
    }
    private void Start()
    {
        UIGame.SetActive(true);
        MenuPause.SetActive(false);
        DefaetMenu.SetActive(false);
        VictoryMenu.SetActive(false);
        Time.timeScale = 1;
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
        foreach (AudioSource audio in list)
        {
            audio.pitch = 0f;
        }
    }

    public void Resume()
    {
        UIGame.SetActive(true);
        MenuPause.SetActive(false);
        Time.timeScale = 1;
        foreach (AudioSource audio in list)
        {
            audio.pitch = 1f;
        }
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }

    public void Next()
    {
        Debug.Log("Next");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
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
