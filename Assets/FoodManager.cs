using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField] public GameObject victory;

    private void Update()
    {
        victory.SetActive(false);
    }

    public void FixUpdate()
    {
        if (transform.childCount==0)
        {
            Debug.Log("¡Ganaste la Demo! Gracias por jugar");
            Show();
            
        }
    }

    public void Show()
    {
        victory.SetActive(true);
    }

}
