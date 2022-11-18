using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIRecipeBookClose : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject recipes;
    [SerializeField] GameObject UIRecipeBook;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] LiquidIngredient[] liquids;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.SetActive(false);
        recipes.SetActive(false);
        UIRecipeBook.SetActive(true);
        UIRecipeBook.GetComponent<TabletButton>().paNoVerElFondo.gameObject.SetActive(false);
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].enable();
        }
        for (int i = 0; i < liquids.Length; i++)
        {
            liquids[i].enable();
        }
    }
}
