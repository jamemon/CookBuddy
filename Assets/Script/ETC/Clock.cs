using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private float _timer = 30;
    public RectTransform hand;
    private bool gameEnd = true;
    private float startTimer = 3f;
    [SerializeField] private TextMeshProUGUI countDownText;

    const float secondToDegree = 360 / 30;

    private bool finsihCount = false;
    // Update is called once per frame

        
    void Update()
    {
        startCountDown();
        if (!gameEnd)
        {
            countDown();
            RotateHand(_timer);
        }
    }
    public bool getGameEnd()
    {
        return gameEnd;
    }
    private void startCountDown()
    {
        
        if(startTimer > 0)
        {
            startTimer -= Time.deltaTime;
            countDownText.text = Mathf.RoundToInt(startTimer).ToString();
        }
        else if(startTimer <= 0 && !finsihCount)
        {
            gameEnd = false;
            countDownText.enabled = false;
            finsihCount = true;
        }
        
    }
    private void RotateHand(float timer)
    {
        hand.rotation = Quaternion.Euler(0, 0, timer * secondToDegree);
    }
    public void countDown()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
    }
    public void stopClock(bool timeOut)
    {
        gameEnd = timeOut;
    }
    public float getTimer()
    {
        return Mathf.Round(_timer * 100f) / 100f; ; 
    }
    

}
