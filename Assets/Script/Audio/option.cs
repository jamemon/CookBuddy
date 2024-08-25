using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class option : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    private void OnEnable()
    {
        musicSlider.value = AudioManager.instance.musicSource.volume;
        sfxSlider.value = AudioManager.instance.sfxSource.volume;
    }
}
