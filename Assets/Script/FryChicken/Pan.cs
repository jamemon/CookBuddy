using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    private int i = 0;
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            if(AudioManager.instance.sfxLoopSource.isPlaying ==  false)
            {
                AudioManager.instance.PlaySFXLoop("Fry");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            i++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            i--;
        }

        if(i == 0 && AudioManager.instance.sfxLoopSource.isPlaying == true)
        {
            AudioManager.instance.sfxLoopSource.Stop();
        }
    }
}
