using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject bowl;
    /*
    private void OnMouseDown()
    {
        bowl.GetComponent<FoodPreparation>().cancelTask();
    }*/
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        bowl.GetComponent<FoodPreparation>().cancelTask();
    }
}
