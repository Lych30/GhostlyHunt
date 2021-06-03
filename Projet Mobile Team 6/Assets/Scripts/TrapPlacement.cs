using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TrapPlacement : MonoBehaviour
{
    private void Start()
    {
        GraphNode node = AstarPath.active.GetNearest(transform.position, NNConstraint.None).node;
        transform.position = (Vector3)node.position;
        AstarPath.active.Scan();
    }
    /*private void OnMouseDrag()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (!AstarPath.active.GetNearest(transform.position).node.Walkable)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0.5f, 0, 0.5f);
        }
    }
    private void OnMouseUp()
    {
        GraphNode node = AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node;
        transform.position = (Vector3)node.position;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        Camera.main.GetComponent<zoomPinch>().enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Obstacles");
    }
    private void OnMouseDown()
    {
        Camera.main.GetComponent<zoomPinch>().enabled = false;
    }*/
}
