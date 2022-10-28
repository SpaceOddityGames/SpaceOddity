using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIRecipeBook : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject recipes;
    [SerializeField] GameObject closeButton;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] LiquidIngredient[] liquids;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.SetActive(false);
        recipes.SetActive(true);
        closeButton.SetActive(true);
        for(int i = 0; i< ingredients.Length; i++)
        {
            ingredients[i].disable();
        }
        for (int i = 0; i < liquids.Length; i++)
        {
            liquids[i].disable();
        }
    }
}
