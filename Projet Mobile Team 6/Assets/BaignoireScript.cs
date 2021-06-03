using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BaignoireScript : MonoBehaviour
{
    public Transform Destination;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private AIDestinationSetter Ai;
    private const float GRIDSIZE = 3;
    public Animator anim;
    private bool used;
    private void Start()
    {
        used = false;
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
        rend = GetComponent<SpriteRenderer>();
        Ai = GameObject.Find("Hero").GetComponent<AIDestinationSetter>();
        anim = GetComponent<Animator>();
    }
    private void OnMouseUpAsButton()
    {
        if (!used && GameManager.StaticMaxManifestation > 0)
        {
            anim.SetTrigger("Trigger");
            used = true;
            rend.material.shader = shaderDefault;
            Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x, transform.position.y - GRIDSIZE), new Quaternion(), transform)); ;
            GameManager.StaticMaxManifestation--;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            AstarPath.active.Scan();

        }
    }
}
