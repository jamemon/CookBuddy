using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FryGameManager : MonoBehaviour
{
    [SerializeField] private Clock clock;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private TextMeshProUGUI grade;
    [SerializeField] private Plate plate;
    [SerializeField] private chickenManager[] chickenManager;

    private bool isPlay = false;
    private void Update()
    {
        CheckWinCon();
    }
    private void CheckWinCon()
    {
        if (plate.getChicCount() == 5 && clock.getTimer() > 0)
        {
            win();
        }
        else if (plate.getChicCount() > 0 && clock.getTimer() <= 0)
        {
            win();
        }
        else if (checkPlate())
        {
            win();
        }
        else if (plate.getChicCount() == 0 && clock.getTimer() <= 0 )
        {
            lose();
        }
        else if (checkBurn())
        {
            lose();
        }

    }
    private void win()
    {
        winUI.SetActive(true);
        grade.text = calGrade();
        clock.stopClock(true);
        if (!isPlay)
        {
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlaySFX("Win", false);
            isPlay = true;
        }
    }
    private void lose()
    {
        loseUI.SetActive(true);
        clock.stopClock(true);
        if (!isPlay)
        {
            AudioManager.instance.musicSource.Stop();
            AudioManager.instance.PlaySFX("Lose", false);
            isPlay = true;
        }
    }
    private string calGrade()
    {
        if (plate.getChicCount() == 5)
        {
            return "A";
        }
        else if (plate.getChicCount() == 4)
        {
            return "B";
        }
        else if (plate.getChicCount() == 3)
        {
            return "C";
        }
        else if (plate.getChicCount() == 2)
        {
            return "D";
        }
        else if (plate.getChicCount() == 1)
        {
            return "E";
        }
        return null;
    }
    private bool checkBurn()
    {
        for (int i = 0; i < chickenManager.Length; i++)
        {
            if( chickenManager[i].getIsburn() == false)
            {
                return false;
            }
        }
        return true;
    }
    private bool checkPlate()
    {
        for (int i = 0; i < chickenManager.Length; i++)
        {
            if (chickenManager[i].getIsPlate() == false)
            {
                return false;
            }
        }
        return true;
    }
}
