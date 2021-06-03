using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject LevelSelector;
    public GameObject GameSetting;

    public void Start()
    {
        StartMenu.SetActive(true);
        LevelSelector.SetActive(false);
        GameSetting.SetActive(false);
    }

    public void Play()
    {
        StartMenu.SetActive(false);
        LevelSelector.SetActive(true);
    }

    public void Setting()
    {
        StartMenu.SetActive(false);
        GameSetting.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Return()
    {
        StartMenu.SetActive(true);
        LevelSelector.SetActive(false);
        GameSetting.SetActive(false);
    }
}
