using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomPinch : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    [SerializeField]
    Transform BottomLeft;
    [SerializeField]
    Transform TopRight;

    // Update is called once per frame
    private void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 0, transform.position.z);
        Camera.main.orthographicSize = 8;
        
    }
    void Update()
    {
      

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if((transform.position + direction).x < TopRight.position.x && (transform.position + direction).x > BottomLeft.position.x && (transform.position + direction).y < TopRight.position.y && (transform.position + direction).y > BottomLeft.position.y)
            {
                Camera.main.transform.position += direction;
            }

        }
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            var TouchPos = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(TouchPos.origin, TouchPos.direction, Mathf.Infinity);
            if (transform.CompareTag("Trap"))
            {
                enabled = false;
            }
            
        }

        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
