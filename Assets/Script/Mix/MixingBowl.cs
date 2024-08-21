using System;
using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("1");
            Endgame();
        }
    }
    public void Endgame()
    {
        loseUi.SetActive(true);
        clock.stopClock(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == list[count])
        {
            count++;
            if(count == list.Count)
            {
                winUi.SetActive(true);
                clock.stopClock(true);
                Grade.text = calGrade();
                TimeLeft.text = clock.getTimer().ToString();
            }
            if (count < 5)
            {
                scrollRect.horizontalNormalizedPosition += 0.25f;
            }

        }
        else
        {
            Endgame();
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
    }
}
