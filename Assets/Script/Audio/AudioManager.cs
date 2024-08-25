using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource ,sfxLoopSource;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject);
        }
        if(PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("sfxVolume"))
        {

            LoadVolume();
        }
    
    }
    private void Start()
    {
        PlayMusic("Music");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.clipName == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");

        }
        else
        {
            musicSource.clip = s.sound;
            musicSource.Play();
        }
    }

    public void PlaySfxWithPitch(string name,float value)
    {
        Sound s = Array.Find(sfxSounds, x => x.clipName == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");

        }
        else
        {

            sfxSource.pitch = value;

            sfxSource.PlayOneShot(s.sound);
        }
    }
    public void PlaySFX(string name,bool changePitch)
    {
        Sound s = Array.Find(sfxSounds, x => x.clipName == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");

        }
        else
        {
            if (changePitch)
            {
                sfxSource.pitch = (UnityEngine.Random.Range(0.9f, 1.1f));
            }
            else
            {
                if(sfxSource.pitch != 1.0f)
                {
                    sfxSource.pitch = 1.0f;
                }
            }
            sfxSource.PlayOneShot(s.sound);
        }
    }
    public void PlaySFXLoop(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.clipName == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");

        }
        else
        {
            sfxLoopSource.clip = s.sound;
            sfxLoopSource.Play();
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        if(sfxLoopSource != null)
        {
            sfxLoopSource.volume = volume;
        }
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            sfxSource.volume = PlayerPrefs.GetFloat("sfxVolume");
        }
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        if (sfxLoopSource != null)
        {
            sfxLoopSource.volume = PlayerPrefs.GetFloat("sfxVolume"); ;
        }
    }

}
