using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class fireplace : MonoBehaviour
{
    public GameObject Flamme;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private Collider2D coll2d;
    private Collider2D herocoll2d;
    private const float GRIDSIZE = 3;
    private bool used;
    private void Start()
    {
        used = false;
        coll2d = GetComponent<Collider2D>();
        herocoll2d = GameObject.Find("Hero").GetComponent<Collider2D>();
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
        rend = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        if (!used && GameManager.StaticMaxTrap > 0)
        {
            StartCoroutine("FlammeTrigger");

        }
    }
    IEnumerator FlammeTrigger()
    {
        GetComponent<Animator>().SetTrigger("Trigger");
        used = true;
        rend.material.shader = shaderDefault;
        Instantiate(Flamme, new Vector3(transform.position.x, transform.position.y - GRIDSIZE), new Quaternion());
        Instantiate(Flamme, new Vector3(transform.position.x, transform.position.y - 2 * GRIDSIZE), new Quaternion());
        GameManager.StaticMaxTrap--;
        AstarPath.active.Scan();
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetTrigger("End");
        AstarPath.active.Scan();

    }

}
