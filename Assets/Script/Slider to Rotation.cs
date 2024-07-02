using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidertoRotation : MonoBehaviour
{
    public Slider Slider;
    public float xLimit = 60f;
    public PourDetection detect;
    // Start is called before the first frame update
    void Start()
    {
        Slider.onValueChanged.AddListener(delegate
        {
            RotateMe();
            detect.detectAngle();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RotateMe()
    {
        transform.localEulerAngles = new Vector3(Slider.value * xLimit, -90,0);
    }
}
