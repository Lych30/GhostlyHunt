using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapTest : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<Animator>().SetTrigger("Activation");
    }
    
}
