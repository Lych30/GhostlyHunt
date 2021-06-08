using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chandelier : MonoBehaviour
{

    public GameObject Debris;
    public GameObject TriggerZone;
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    private Collider2D coll2d;
    private Collider2D herocoll2d;
    [SerializeField]private Sprite[] debris;
    [SerializeField]private Sprite tombé;
    private GameObject debrisGO;
    private const float GRIDSIZE = 3;
    public AudioSource CrashAudio;
    private bool used;

    private int touchCount;
    private float TimeTuch = 1f;

    private void Start()
    {
        used = false;
        rb = GetComponent<Rigidbody2D>();
        coll2d = TriggerZone.GetComponent<Collider2D>();
        herocoll2d = GameObject.Find("Hero").GetComponent<Collider2D>();
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
        rend = GetComponent<SpriteRenderer>();
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
            if (!used && !Physics2D.Distance(coll2d, herocoll2d.GetComponent<Collider2D>()).isOverlapped && GameManager.StaticMaxTrap > 0 && touchCount == 2)
            {
                StartCoroutine("tombe");
                GameManager.StaticMaxTrap--;
                GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            }
        }
    }

    IEnumerator tombe()
    {
        rend.material.shader = shaderDefault;
        rb.gravityScale = 1;
        yield return new WaitForSeconds(1.63f);
        rend.enabled = false;
        debrisGO = Instantiate(Debris, new Vector3(transform.position.x + GRIDSIZE, transform.position.y), new Quaternion());
        debrisGO.GetComponent<SpriteRenderer>().sprite = debris[Random.Range(0, 3)];
        debrisGO = Instantiate(Debris, new Vector3(transform.position.x - GRIDSIZE, transform.position.y), new Quaternion());
        debrisGO.GetComponent<SpriteRenderer>().sprite = debris[Random.Range(0, 3)];
        debrisGO = Instantiate(Debris, new Vector3(transform.position.x, transform.position.y + GRIDSIZE), new Quaternion());
        debrisGO.GetComponent<SpriteRenderer>().sprite = debris[Random.Range(0, 3)];
        debrisGO = Instantiate(Debris, new Vector3(transform.position.x, transform.position.y - GRIDSIZE), new Quaternion());
        debrisGO.GetComponent<SpriteRenderer>().sprite = debris[Random.Range(0, 3)];
        debrisGO = Instantiate(Debris, transform.position, new Quaternion());
        debrisGO.GetComponent<SpriteRenderer>().sprite = tombé;
        coll2d.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        CrashAudio.Play();
        Destroy(gameObject,2);
        //Destroy(GetComponent<Rigidbody2D>());
        AstarPath.active.Scan();
    }
}
