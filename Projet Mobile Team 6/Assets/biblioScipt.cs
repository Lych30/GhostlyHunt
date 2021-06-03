using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biblioScipt : MonoBehaviour
{
    private Shader shaderDefault;
    private void Start()
    {
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
    }
    private void OnMouseUpAsButton()
    {
        if (GameManager.StaticMaxTrap > 0)
        {
            GetComponent<Animator>().SetTrigger("fall");
            GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, -2.63f);
            GetComponent<SpriteRenderer>().material.shader = shaderDefault;
            GameManager.StaticMaxTrap--;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            AstarPath.active.Scan();
        }

    }
}
