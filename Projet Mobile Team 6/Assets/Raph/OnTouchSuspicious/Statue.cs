using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Statue : MonoBehaviour
{
    public Transform Destination;
    private GameObject hero;
    public GameObject TriggerZone;
    private Collider2D coll2d;
    private Collider2D herocoll2d;
    private AIDestinationSetter Ai;
    private AIPath AiPath;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private const float GRIDSIZE = 3;
    private bool used;

    //Orientation
    private enum Orientation { UP, LEFT, DOWN, RIGHT }
    [SerializeField] private Orientation orientation;

    // Start is called before the first frame update
    void Start()
    {
        used = false;
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
        rend = GetComponent<SpriteRenderer>();
        coll2d = TriggerZone.GetComponent<Collider2D>();
        hero = GameObject.Find("Hero");
        herocoll2d = hero.GetComponent<Collider2D>();
        Ai = hero.GetComponent<AIDestinationSetter>();
        AiPath = hero.GetComponent<AIPath>();
    }


    private void OnMouseUpAsButton()
    {
        if (coll2d != null && herocoll2d != null)
        {
            if (Ai != null && !used && GameObject.Find("PriorityDestination(Clone)") == null && Physics2D.Distance(coll2d, herocoll2d.GetComponent<Collider2D>()).isOverlapped && GameManager.StaticMaxManifestation>0)
            {

                AiPath.maxSpeed = 6;
                rend.material.shader = shaderDefault;
                used = true;
                GameManager.StaticMaxManifestation--;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
                herocoll2d.gameObject.GetComponent<Animator>().SetTrigger("Fear");
                GetComponent<Animator>().SetTrigger("Trigger");
                switch (orientation)
                {

                    case Orientation.UP:
                        Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x, transform.position.y + 5 * GRIDSIZE), new Quaternion()));
                        break;

                    case Orientation.DOWN:
                        Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x, transform.position.y - 5 * GRIDSIZE), new Quaternion()));
                        break;

                    case Orientation.LEFT:
                        Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x - 5 * GRIDSIZE, transform.position.y), new Quaternion()));
                        break;

                    case Orientation.RIGHT:
                        Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x + 5 * GRIDSIZE, transform.position.y), new Quaternion()));
                        break;

                    default:
                        break;
                }
            }
        }
    }
    
}
