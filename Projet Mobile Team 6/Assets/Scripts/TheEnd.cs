using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;


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
            if(gameObject.CompareTag("LooseZone"))
            {
                collision.GetComponent<Animator>().SetTrigger("Crying");
                collision.GetComponent<Animator>().SetBool("IsCrying",true);
                Social.ReportProgress("CgkIy8DmhfsXEAIQAQ", 100, success => { });
                collision.GetComponent<check>().End.Play(); 
            }
            StartCoroutine(Fin());
        }
    }
    IEnumerator Fin()
    {
        yield return new WaitForSeconds(1.5f);
        Win.SetActive(true);

        if(SceneManager.GetActiveScene().name == "Tuto")
        {
            Social.ReportProgress("CgkIy8DmhfsXEAIQAA", 100, success => { });
        }
        
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            Social.ReportProgress("CgkIy8DmhfsXEAIQCw", 100, success => { });
        }
        
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            Social.ReportProgress("CgkIy8DmhfsXEAIQDA", 100, success => { });
        }

        UIGame.SetActive(false);
        Time.timeScale = 0;
    }
}
