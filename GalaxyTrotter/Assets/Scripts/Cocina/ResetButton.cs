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
        FindObjectOfType<AudioManager>().Play("botonMenu");
        FindObjectOfType<AudioManager>().Stop("liquido");
        FindObjectOfType<AudioManager>().Stop("liquido2");
        bowl.GetComponent<FoodPreparation>().resetFoodGame();
    }

}
