using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public GameObject ChickenLegPrefab;
    public float startForce = 15f;
    [SerializeField] private GameObject gameManager;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        gameManager = GameObject.FindWithTag("Manager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            Vector3 direction = (collision.transform.position - transform.forward).normalized;
            quaternion rotation = Quaternion.LookRotation(direction);
            GameObject chickLeg = Instantiate(ChickenLegPrefab,transform.position,rotation);
            Destroy(chickLeg,3f);
            gameManager.GetComponent<FruitGameManager>().AddChickenCount();
            Destroy(gameObject);
        }
       if (collision.CompareTag("Bound"))
        {
            gameManager.GetComponent<FruitGameManager>().AddChickenDropCount();
            Destroy(gameObject);
        }
    }

}
