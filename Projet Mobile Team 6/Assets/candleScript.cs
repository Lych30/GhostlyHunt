using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class candleScript : MonoBehaviour
{
    BoxCollider2D boxcol;
    private Shader shaderDefault;
    bool isactivated;
    private void Start()
    {
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
    }
    public void OnMouseUpAsButton()
    {
        if(!isactivated)
        {
            boxcol = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
            boxcol.size = new Vector3(10, 10, 3);
            AstarPath.active.Scan();
            GetComponent<Animator>().SetTrigger("Off");
            GetComponent<SpriteRenderer>().material.shader = shaderDefault;
            isactivated = true;
        }
        
    }
}
