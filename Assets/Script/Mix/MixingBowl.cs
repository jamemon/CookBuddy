using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixingBowl : MonoBehaviour
{
    private List<string> list;
    public ScrollRect scrollRect;
    private int count = 0;
    [SerializeField] private GameObject winUi;
    [SerializeField] private GameObject loseUi;
    // Start is called before the first frame update
    void Start()
    {
        list = new List<string>() { "Chicken","Oil","Honey","Mix","Salt"};
        
    }


    void Update()
    {
        
    }
    public void check()
    {

    }
    public void Endgame()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == list[count])
        {
            count++;
            if (count < 5)
            {
                scrollRect.horizontalNormalizedPosition += 0.25f;
            }
        }
    }
}
