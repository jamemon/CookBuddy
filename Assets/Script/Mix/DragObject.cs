using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    Vector3 mousePosition;
    private bool hit = false;
    private Vector3 getMousesPos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePosition= Input.mousePosition - getMousesPos();
    }
    private void OnMouseDrag()
    {
        if (!hit)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bowl"))
        {
            hit = true;
        }
    }
}
