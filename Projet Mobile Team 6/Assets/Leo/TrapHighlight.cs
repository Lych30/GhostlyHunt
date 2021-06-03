using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapHighlight : MonoBehaviour
{
    public Shader HighlightShader;
    public GameObject[] trapsList;
    // Start is called before the first frame update
    
    void Awake()
    {
        trapsList = GameObject.FindGameObjectsWithTag("Trap");
        foreach (GameObject go in trapsList)
        {
            go.GetComponent<Renderer>().material.shader = HighlightShader;
        }
    }
}
