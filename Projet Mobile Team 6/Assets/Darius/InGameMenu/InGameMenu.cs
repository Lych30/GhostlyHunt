using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InGameMenu : MonoBehaviour
{
    public GameObject UIGame;
    public GameObject MenuPause;
    public GameObject DefaetMenu;
    public GameObject VictoryMenu;

    [Header("Loading Scene")]
    public GameObject LoadinScreen;
    public Slider LoadingProgress;
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

        //OLD
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);

        //NEW
        StartCoroutine(Loading(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void MainMenu()
    {
        //OLD
        //SceneManager.LoadScene("MainMenu");

        //NEW
        StartCoroutine(Loading("MainMenu"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    //LOADING SCENES
    IEnumerator Loading(string name)
    {
        LoadinScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        
        while (!operation .isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingProgress.value = progress;
            yield return null;
        }
    }
    IEnumerator Loading(int index)
    {
        LoadinScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingProgress.value = progress;
            yield return null;
        }
    }

}
