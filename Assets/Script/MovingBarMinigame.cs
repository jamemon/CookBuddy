using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarMinigame : MonoBehaviour
{
    [SerializeField] Transform leftPivot;
    [SerializeField] Transform RightPivot;

    [SerializeField] Transform indicator;
    private float indicatorPosition;
    private float indicatorDestination;
    [SerializeField] private float indicatorVelocity;
    [SerializeField] float smoothMotion = .5f;
    [SerializeField] float maxSpeed;
    private float timer;
    [SerializeField] float timerBase = 3f;


    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            timer = timerBase;
            if (indicatorDestination == 1f)
            {
                indicatorDestination = 0f;
            }
            else
            {
                indicatorDestination = 1f;
            }
        }
        
            indicatorPosition = Mathf.SmoothDamp(indicatorPosition, indicatorDestination, ref indicatorVelocity, smoothMotion,maxSpeed);
            indicator.position = Vector3.Lerp(leftPivot.position,RightPivot.position, indicatorPosition);
        
        
    }
}
