using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField]private int chicCount;

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chicken"))
        {
            chickenManager manager = other.GetComponent<chickenManager>();
            if (manager.getIsCooked() && !manager.getIsPlate() && !manager.getIsburn())
            {
                chicCount++;
                manager.setIsPlate(true);
            }
        }
    }
    public int getChicCount()
    {
        return chicCount;
    }
  
}
