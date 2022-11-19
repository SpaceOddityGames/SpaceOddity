using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrepareButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject bowl;
    /*
    private void OnMouseDown()
    {
        bowl.GetComponent<FoodPreparation>().preparationResult();
    }*/
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        bowl.GetComponent<FoodPreparation>().preparationResult();
    }
}
