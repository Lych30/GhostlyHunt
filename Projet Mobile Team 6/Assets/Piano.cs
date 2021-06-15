using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Piano : MonoBehaviour
{
    public AudioSource Rick;
    public Transform Destination;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private AIDestinationSetter Ai;
    private const float GRIDSIZE = 3;
    private Animator anim;
    private bool used;

    private int touchCount;
    private float TimeTuch = 1f;

    private void Start()
    {
        used = false;
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
        rend = GetComponent<SpriteRenderer>();
        Ai = GameObject.Find("Hero").GetComponent<AIDestinationSetter>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (touchCount == 1)
        {
            TimeTuch -= Time.deltaTime;
        }

        if (TimeTuch <= 0)
        {
            touchCount = 0;
            TimeTuch = 1f;
        }
    }
    private void OnMouseUpAsButton()
    {
        touchCount++;
        if (!used && GameManager.StaticMaxManifestation > 0 && touchCount == 2)
        {
            Social.ReportProgress("CgkIy8DmhfsXEAIQAg", 1, success => { });
            Rick.Play();
            GameObject.Find("GameManager").GetComponent<AudioSource>().pitch = 0;
            anim.SetTrigger("Trigger");
            used = true;
            rend.material.shader = shaderDefault;
            Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x, transform.position.y - 2 * GRIDSIZE), new Quaternion(),transform)); ;
            GameManager.StaticMaxManifestation--;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            AstarPath.active.Scan();
            
        }
    }
    
}
