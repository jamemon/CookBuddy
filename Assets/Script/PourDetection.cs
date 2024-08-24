using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PourDetection : MonoBehaviour
{
    public int pourThreshold = 45;
    public ParticleSystem myParticleSystem;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectAngle();
        Debug.Log(Vector3.Angle(Vector3.down, transform.forward));
        Debug.Log(myParticleSystem.isPlaying);
    }

    public void detectAngle()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) <= 70f)
        {
            if (myParticleSystem.isPlaying == false)
            {
                myParticleSystem.Play();
            }
        }
        else
        {
            myParticleSystem.Stop();
            myParticleSystem.Clear() ;
        }
    }
}

