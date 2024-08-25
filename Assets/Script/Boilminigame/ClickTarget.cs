using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickTarget : MonoBehaviour
{
    public bool _IsinBound;
    private bool _IsClickAllCorrect;
    public int _ClickCount = 0;
    [SerializeField]private Image[] _clickCorrect;
    private float position;
    [SerializeField] RectTransform _rectTransform;

    public Clock clock;
    public ClickTarget target;
    public GameObject WinUI;
    public GameObject LoseUI;
    public TextMeshProUGUI Grade;
    public TextMeshProUGUI TimeLeft;

    public bool isEnd = false;


    private bool isPlay = false;
    private void FixedUpdate()
    {
        checkWinCon();
    }

    public void WhenClick() 
    {
        if (_IsinBound && !clock.getGameEnd())
        {
            AudioManager.instance.PlaySFX("Correct",true);
            if (_ClickCount < 3)
            {
                _clickCorrect[_ClickCount].color = Color.green;
                _ClickCount++;
                
                randomPosition();
            }
            

        }
    
    }
    private void randomPosition()
    {
        position = Random.Range(-250, 250);
        _rectTransform.localPosition = new Vector3(position, 0, 0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
       _IsinBound = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        _IsinBound = false;
    }

    private string calGrade()
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


    public void checkWinCon()
    {


        if (clock.getTimer() > 0 && target._ClickCount == 3)
        {
            clock.stopClock(true);
            WinUI.SetActive(true);
            Grade.text = calGrade();
            TimeLeft.text = clock.getTimer().ToString();
            
            if (!isPlay)
            {
                AudioManager.instance.musicSource.Stop();
                AudioManager.instance.PlaySFX("Win",false);
                isPlay = true;
            }

        }
        else if(clock.getTimer() <= 0)
        {
            LoseUI.SetActive(true);
            clock.stopClock(true);
            if (!isPlay)
            {
                AudioManager.instance.musicSource.Stop();
                AudioManager.instance.PlaySFX("Lose",false);
                isPlay = true;
            }
        }
        isEnd = clock.getGameEnd();
    }

}
