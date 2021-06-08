using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biblioScipt : MonoBehaviour
{
    [SerializeField]AudioSource BiblioAudio;
    private Shader shaderDefault;

    private int touchCount;
    private float TimeTuch = 1f;
    private void Start()
    {
        shaderDefault = GameObject.Find("GameManager").GetComponent<GameManager>().defaultshader;
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
        if (GameManager.StaticMaxTrap > 0 && touchCount == 2)
        {
            BiblioAudio.Play();
            GetComponent<Animator>().SetTrigger("fall");
            GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, -2.63f);
            GetComponent<SpriteRenderer>().material.shader = shaderDefault;
            GameManager.StaticMaxTrap--;
            GameObject.Find("GameManager").GetComponent<GameManager>().UpdateUiText();
            AstarPath.active.Scan();
        }

    }
}
