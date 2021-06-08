using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TheEnd : MonoBehaviour
{
    public GameObject Win;
    public GameObject UIGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<AIPath>().canMove = false;
            collision.GetComponent<Animator>().SetTrigger("Crying");
            collision.GetComponent<Animator>().SetBool("IsCrying",true);
            StartCoroutine(Fin());
        }
    }
    IEnumerator Fin()
    {
        yield return new WaitForSeconds(1.5f);
        Win.SetActive(true);
        UIGame.SetActive(false);
        Time.timeScale = 0;
    }
}
