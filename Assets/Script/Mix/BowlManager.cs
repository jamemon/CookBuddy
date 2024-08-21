using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlManager : MonoBehaviour
{
    public GameObject spawnpoint;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bowl"))
        {
            transform.position = spawnpoint.transform.position; 
        }
    }

}
