using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hole : MonoBehaviour
{
    private void Start()
    {

        if(GameManager.StaticMaxTrap>0)
        {
            gameObject.layer = 3;
            GameManager.StaticMaxTrap--;
        }

    }
}
