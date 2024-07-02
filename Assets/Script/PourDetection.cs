using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PourDetection : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject streamPrefab = null;
    public ParticleSystem myParticleSystem;

    private bool isPouring = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectAngle();
        Debug.Log(Vector3.Angle(Vector3.down, transform.forward));
    }

    public void detectAngle()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) <= 60f)
        {
            myParticleSystem.Play();
        }
        else
        {
            myParticleSystem.Stop();
        }
    }
}

