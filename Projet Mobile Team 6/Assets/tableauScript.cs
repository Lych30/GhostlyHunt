using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class tableauScript : MonoBehaviour
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
    public AudioSource TableauAudio;
    private bool used;

    private int touchCount;
    private float TimeTuch = 1f;

    [SerializeField] int DestinationX;
    [SerializeField] int DestinationY;

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
        if (coll2d != null && herocoll2d != null)
        {
            touchCount++;
            if (Ai != null && !used && GameObject.Find("PriorityDestination(Clone)") == null && Physics2D.Distance(coll2d, herocoll2d.GetComponent<Collider2D>()).isOverlapped && GameManager.StaticMaxManifestation > 0 && touchCount == 2)
            {
                TableauAudio.Play();
                Handheld.Vibrate();
                AiPath.maxSpeed = 6;
                rend.material.shader = shaderDefault;
                used = true;
                GameManager.StaticMaxManifestation--;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
                herocoll2d.gameObject.GetComponent<Animator>().SetTrigger("Fear");
                GetComponent<Animator>().SetTrigger("Trigger");
                Ai.SetTarget(Instantiate(Destination, new Vector3(transform.position.x + DestinationX * GRIDSIZE, transform.position.y + DestinationY * GRIDSIZE), new Quaternion()));
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x + DestinationX * GRIDSIZE, transform.position.y + DestinationY * GRIDSIZE), 0.5f);
    }
}
