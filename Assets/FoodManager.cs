using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{

    private void Update()
    {
        AllFoodCollected();
    }

    public void AllFoodCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("No quedan frutas, Victoria");
        }
    }



}
