using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public GameObject Win;
    public GameObject UIGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Win.SetActive(true);
            UIGame.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
