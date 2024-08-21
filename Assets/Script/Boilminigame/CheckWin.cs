using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    private Clock clock;
    private ClickTarget target;
    private GameObject popUp;
    public TextMeshPro Grade;
    public TextMeshPro TimeLeft;

    public void checkWinCon()
    {
        if(clock.getTimer() > 0 && target._ClickCount == 3)
        {
            clock.stopClock(true);
            popUp.SetActive(true);
            Grade.text = calGrade();
            TimeLeft.text = clock.getTimer().ToString();
        }
    }

    private string calGrade()
    {
        if(clock.getTimer() >= 20f)
        {
            return "A";
        }
        else if(clock.getTimer() < 20 && clock.getTimer() > 10)
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
