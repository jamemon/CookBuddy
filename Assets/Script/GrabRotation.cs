using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRotation : MonoBehaviour
{
    private float _rotationSpeed = 1f;
  
    private void OnMouseDrag()
    {
        float ZaxisRotation = Input.GetAxis("Mouse Y") * _rotationSpeed;

        transform.Rotate(Vector3.right, ZaxisRotation);
    }
}
