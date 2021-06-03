using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour
{
    private bool isUsed = false;
    private SpriteRenderer rend;
    private Shader shaderDefault;
    public Sprite Ferme;

    private void Start()
    {
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
        rend = GetComponent<SpriteRenderer>();

    }
    private void OnMouseDown()
    {
        if (GameManager.StaticMaxKey > 0 && !isUsed)
        {
            GameManager.StaticMaxKey--;
            rend.sprite = Ferme;
            rend.material.shader = shaderDefault;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            GetComponent<Collider2D>().enabled = true;
            gameObject.layer = 3;
            AstarPath.active.Scan();
            isUsed = true;
        }
        
    }
}
