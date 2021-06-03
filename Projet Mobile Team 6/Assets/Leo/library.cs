using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class library : MonoBehaviour
{
    public GameObject Obstacle;
    private void Start()
    {
        Instantiate(Obstacle, new Vector3(transform.position.x + GetComponent<TrapTrigger>().scaleX, transform.position.y + GetComponent<TrapTrigger>().scaleY), new Quaternion());
    }
}
