using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class LavaboLeft_Right : MonoBehaviour
{
    public Transform Destination;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private AIDestinationSetter Ai;
    private const float GRIDSIZE = 3;
    public Animator anim;
    private bool used;

    private enum Orientation { LEFT,RIGHT }
    [SerializeField] private Orientation orientation;

    private void Start()
    {
        used = false;
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
        rend = GetComponent<SpriteRenderer>();
        Ai = GameObject.Find("Hero").GetComponent<AIDestinationSetter>();
        anim = GetComponent<Animator>();
        switch (orientation)
        {
            case Orientation.LEFT:
                GetComponent<SpriteRenderer>().flipX = false;
                break;
            case Orientation.RIGHT:
                GetComponent<SpriteRenderer>().flipX = true;
                break;
        }
    }
    private void OnMouseUpAsButton()
    {
        if (!used && GameManager.StaticMaxManifestation > 0)
        {
            anim.SetTrigger("Trigger");
            used = true;
            rend.material.shader = shaderDefault;

            switch (orientation)
            {
                case Orientation.LEFT:
                    Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x - GRIDSIZE, transform.position.y), new Quaternion(), transform));
                    break;
                case Orientation.RIGHT:
                    Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x + GRIDSIZE, transform.position.y), new Quaternion(), transform));
                    break;
            }
           
            GameManager.StaticMaxManifestation--;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            AstarPath.active.Scan();

        }
    }
}
