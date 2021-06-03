using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerateAndSlowDown : MonoBehaviour
{
    public Sprite x2;
    public Sprite x1;
    public void Accelerate()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 2;
            GetComponent<Button>().image.sprite = x2;
        }
        else
        {
            Time.timeScale = 1;
            GetComponent<Button>().image.sprite = x1;
        }
    }
    public void StopTime()
    {
        Time.timeScale = 0;
    }
}
