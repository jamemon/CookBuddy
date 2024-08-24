using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;


public class chickenManager : MonoBehaviour
{
    [SerializeField] private CircleFillHandler circleFillHandler;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Material startMaterial;
    [SerializeField] private Material targetMaterial;
    [SerializeField] private Material burnMaterial;
    [SerializeField] private Renderer ren;
    public Image image;
    
    private Vector3 LastPosition;
    private Transform canvasCurrentPosition;

    private float timer = 0;

    private float timeToCook = 5f;
    private float timeToBurn = 3f;

    private bool isCooked = false;
    private bool isPlate = false;
    private bool isBurn = false;
    private void Start()
    {
        LastPosition = transform.position;
    }

    private void Update()
    {
      OnPositionChange();
    }
    void OnPositionChange()
    {
        if(transform.position != LastPosition)
        {
            canvas.transform.position = transform.position + new Vector3(-0.5f,0.5f,0);
        }
        LastPosition = transform.position;
    }
    void updateTimer()
    {
        if (!isCooked)
        {
            if (timer < timeToCook)
            {

                if (canvas.activeSelf == false)
                {
                    canvas.SetActive(true);

                }
                fillCircleBar(timer, timeToCook,startMaterial,targetMaterial);

                timer += Time.deltaTime;

            }
            else
            {
                isCooked = true;
                timer = 0;
                canvas.SetActive(false);
            }
        }
        else if(isCooked && !isBurn)
        {
            if (timer < timeToBurn)
            {

                if (canvas.activeSelf == false)
                {
                    canvas.SetActive(true);
                    image.color = Color.red;

                }
                fillCircleBar(timer, timeToBurn, targetMaterial, burnMaterial);

                timer += Time.deltaTime;

            }
            else
            {
                isBurn = true;
                timer = 0;
                canvas.SetActive(false);
            }
        }
    }

    private void fillCircleBar(float timer, float targetTime ,Material mat1, Material mat2)
    {
        float value = (timer / targetTime) * 100;
        ren.material.Lerp(mat1, mat2, value / 100);
        circleFillHandler.FillCircleValue(value);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pan"))
        {
            updateTimer();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pan"))
        {
            setCanvas(false);
        }
    }
    public void setCanvas(bool b)
    {
        canvas.SetActive(b);
    }
    public bool getIsCooked()
    {
        return isCooked;
    }
    public bool getIsPlate()
    {
        return isPlate;
    }
    public void setIsPlate(bool b)
    {
        isPlate = b;
    }
    public bool getIsburn()
    {
        return isBurn;
    }
}
