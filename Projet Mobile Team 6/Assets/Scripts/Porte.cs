using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    private bool isUsed = false;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    public Sprite Ferme;

    private int touchCount;
    private float TimeTuch = 1f;

    private void Start()
    {
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
        touchCount++;
        if (GameManager.StaticMaxKey > 0 && !isUsed && touchCount == 2)
        {
            GameManager.StaticMaxKey--;
            rend.sprite = Ferme;
            rend.material.shader = shaderDefault;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            GetComponent<Collider2D>().enabled = true;
            gameObject.layer = 3;
            AstarPath.active.Scan();
            isUsed = true;
            transform.position += new Vector3(-1.35f, 1,1);
        }
        
    }
}
