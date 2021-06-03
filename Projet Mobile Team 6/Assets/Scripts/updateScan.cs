using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class updateScan : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        AstarPath.active.Scan();
    }
}
