using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{
    [SerializeField] GameObject[] ingredients;
    [SerializeField] GameObject[] liquidIngredients;
    [SerializeField] GameObject[] buttons;
    public void disableAll()
    {
        foreach(GameObject ingredient in ingredients)
        {
            ingredient.GetComponent<Ingredient>().enabled = false;
        }
        foreach (GameObject liquidIngredient in liquidIngredients)
        {
            liquidIngredient.GetComponent<LiquidIngredient>().enabled = false;
        }
    }
    public void enableAll()
    {
        foreach (GameObject ingredient in ingredients)
        {
            ingredient.GetComponent<Ingredient>().enabled = true;
        }
        foreach (GameObject liquidIngredient in liquidIngredients)
        {
            liquidIngredient.GetComponent<LiquidIngredient>().enabled = true;
        }
    }
}
