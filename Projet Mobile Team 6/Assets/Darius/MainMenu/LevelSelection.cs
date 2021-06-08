using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [Header("Loading Scene")]
    public GameObject LoadinScreen;
    public Slider LoadingProgress;

    public void LoadLevel(int LevelToLoad)
    {
        //OLD
        //SceneManager.LoadScene(LevelToLoad,LoadSceneMode.Single);

        //NEW
        StartCoroutine(Loading(LevelToLoad));
    }

    IEnumerator Loading(string name)
    {
        LoadinScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        while (!operation.isDone)
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
