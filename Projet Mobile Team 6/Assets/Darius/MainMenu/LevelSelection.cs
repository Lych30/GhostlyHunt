using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void LoadLevel(int LevelToLoad)
    {
        SceneManager.LoadScene(LevelToLoad,LoadSceneMode.Single);
    }

}
