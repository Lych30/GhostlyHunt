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
    private bool used;

    private void Start()
    {
        used = false;
        rb = GetComponent<Rigidbody2D>();
        coll2d = TriggerZone.GetComponent<Collider2D>();
        herocoll2d = GameObject.Find("Hero").GetComponent<Collider2D>();
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
        rend = GetComponent<SpriteRenderer>();
    }


    private void OnMouseUpAsButton()
    {
        if (coll2d != null && herocoll2d != null)
        {
            if (!used && !Physics2D.Distance(coll2d, herocoll2d.GetComponent<Collider2D>()).isOverlapped && GameManager.StaticMaxTrap > 0)
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
        Destroy(gameObject);
        //Destroy(GetComponent<Rigidbody2D>());
        AstarPath.active.Scan();
    }
}
