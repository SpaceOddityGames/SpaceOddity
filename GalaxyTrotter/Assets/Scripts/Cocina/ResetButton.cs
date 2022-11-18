using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ResetButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject bowl;
    /*
    private void OnMouseDown()
    {
        bowl.GetComponent<FoodPreparation>().resetFood();
        bowl.GetComponent<FoodPreparation>().reseted = true;
    }*/
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        bowl.GetComponent<FoodPreparation>().resetFood();
        bowl.GetComponent<FoodPreparation>().reseted = true;
    }

}
