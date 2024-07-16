using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickTarget : MonoBehaviour
{
    public bool _IsinBound;
    private bool _IsClickAllCorrect;
    private int _ClickCount = 0;
    [SerializeField]private Image[] _clickCorrect;
    private float position;
    [SerializeField] RectTransform _rectTransform;
    public void whenClick() 
    {
        if (_IsinBound)
        {
            _clickCorrect[_ClickCount].color = Color.green;
            if (_ClickCount < 2)
            {
                _ClickCount++;
            }
            randomPosition();
        }
        else
        {
            //randomPosition();
            Debug.Log("not click on time nay");
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
   
}
