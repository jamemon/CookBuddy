using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider MusicSlider, SFXSlider;
  
    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(MusicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(SFXSlider.value);
        
    }
}
