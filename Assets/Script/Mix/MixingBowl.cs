using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MixingBowl : MonoBehaviour
{
    private List<string> list;
    public ScrollRect scrollRect;
    private int count = 0;
    [SerializeField] private GameObject winUi;
    [SerializeField] private GameObject loseUi;
    [SerializeField] private Clock clock;
    public TextMeshProUGUI Grade;
    public TextMeshProUGUI TimeLeft;
    private bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        list = new List<string>() { "Chicken","Oil","Honey","Mix","Salt"};
        
    }


    void Update()
    {
        check();
    }
    public void check()
    {
        if(clock.getTimer() <= 0)
        {
            lose();
        }
    }
    public void Endgame()
    {
        loseUi.SetActive(true);
        clock.stopClock(true);
    }
    public void chooseSound(string name)
    {
        if(name == "Salt" || name == "Mix")
        {
            AudioManager.instance.PlaySFX("Spice",true);
        }
        else
        {
            AudioManager.instance.PlaySFX("Water", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == list[count])
        {
            chooseSound(list[count]);
            count++;
            if(count == list.Count)
            {
                win();
            }
            if (count < 5)
            {
                scrollRect.horizontalNormalizedPosition += 0.25f;
            }

        }
        else
        {
            lose();
        }

       
    }
    string calGrade()
    {
        if (clock.getTimer() >= 20f)
        {
            return "A";
        }
        else if (clock.getTimer() < 20 && clock.getTimer() > 10)
        {
            return "B";
        }
        else if (clock.getTimer() < 10 && clock.getTimer() > 0)
        {
            return "C";
        }
        return "F";
    }
    private void win()
    {
        winUi.SetActive(true);
        Grade.text = calGrade();
        clock.stopClock(true);
        TimeLeft.text = clock.getTimer().ToString();
        if (!isPlay)
        {
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlaySFX("Win", false);
            isPlay = true;
        }
    }
    private void lose()
    {
        loseUi.SetActive(true);
        clock.stopClock(true);
        if (!isPlay)
        {
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlaySFX("Lose", false);
            isPlay = true;
        }
    }
}
