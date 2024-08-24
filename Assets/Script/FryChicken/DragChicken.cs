using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragChicken : MonoBehaviour
{
    Vector3 mousePosition;
    
    private Vector3 getMousesPos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {

        mousePosition = Input.mousePosition - getMousesPos();
    }
    private void OnMouseDrag()
    {

            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
    }

