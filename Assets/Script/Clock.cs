using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private bool _timeOut = false;
    [SerializeField]private float _timer = 30;
    public RectTransform hand;

    const float secondToDegree = 360 / 30;
    // Update is called once per frame
    void Update()
    {
        countDown();
        RotateHand(_timer);
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
        else 
        { 
            _timeOut = true;
        }
    }
}
