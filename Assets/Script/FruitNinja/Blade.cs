using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minCuttingVelocity = 0.001f;
    public GameObject bladeTrail;
    bool isCutting = false;
    Rigidbody2D rb;
    [SerializeField] Camera cam;
    GameObject currentBladeTrail;
    CircleCollider2D circleCollider;

    Vector2 previousPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }
    }
    void UpdateCut()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        float velocity = (newPos - previousPosition).magnitude / Time.deltaTime;
        if(velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPos;
    }

    void StartCutting()
    {
        if (!isCutting) 
        {
            rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = rb.position;
            currentBladeTrail = Instantiate(bladeTrail, transform);
            isCutting = true;
            circleCollider.enabled = false;
        }
        
        
    }
    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail,2f);
        circleCollider.enabled = false;
    }
}
