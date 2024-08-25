using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitGameManager : MonoBehaviour
{
    private int chickenCount;
    private int chickenDropCount;
    [SerializeField] private GameObject WinUi;
    [SerializeField] private GameObject LoseUi;
    [SerializeField] private GameObject bound;
    [SerializeField] private Clock clock;
    [SerializeField] private TextMeshProUGUI grade;
    [SerializeField] private TextMeshProUGUI chickText;
    [SerializeField] private TextMeshProUGUI chickCountText;
    [SerializeField] private GameObject spawner;

    private bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkWinCon();
        if (!clock.getGameEnd())
        {
            spawner.SetActive(true);
        }
    }
    private void checkWinCon()
    {
        if(chickenDropCount == 5)
        {
            clock.stopClock(true);
            bound.SetActive(false);
            LoseUi.SetActive(true);
            if (!isPlay)
            {
                AudioManager.instance.musicSource.Stop();
                AudioManager.instance.PlaySFX("Lose", false);
                isPlay = true;
            }
        }
        if (clock.getTimer() <= 0) 
        {
            clock.stopClock(true);
            bound.SetActive(false);
            WinUi.SetActive(true);
            grade.text = calGrade();
            chickText.text = chickenCount.ToString();
            if (!isPlay)
            {
                AudioManager.instance.musicSource.Stop();
                AudioManager.instance.PlaySFX("Win", false);
                isPlay = true;
            }
        }
    }
    public void AddChickenCount()
    {
        chickenCount++;
        AudioManager.instance.PlaySFX("Cut", true);
        chickCountText.text = chickenCount.ToString();
    }
    public void AddChickenDropCount()
    {
        chickenDropCount++;
        AudioManager.instance.PlaySFX("Drop",true);
    }

    private string calGrade()
    {
        if (chickenDropCount == 0)
        {
            return "A";
        }
        else if (chickenDropCount == 1)
        {
            return "B";
        }
        else if (chickenDropCount == 2)
        {
            return "C";
        }
        else if (chickenDropCount == 3)
        {
            return "D";
        }
        else if (chickenDropCount == 4)
        {
            return "E";
        }
        return null;
    }
}
