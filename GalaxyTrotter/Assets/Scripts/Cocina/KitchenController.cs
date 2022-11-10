using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{
    [SerializeField] GameObject[] ingredients;
    [SerializeField] GameObject[] liquidIngredients;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject tablet;
    public void disableAll()
    {
        foreach (GameObject ingredient in ingredients)
        {
            ingredient.GetComponent<Ingredient>().disable();
        }
        foreach (GameObject liquidIngredient in liquidIngredients)
        {
            liquidIngredient.GetComponent<LiquidIngredient>().disable();
        }
    }
    public void enableAll()
    {
        foreach (GameObject ingredient in ingredients)
        {
            ingredient.GetComponent<Ingredient>().enable();
        }
        foreach (GameObject liquidIngredient in liquidIngredients)
        {
            liquidIngredient.GetComponent<LiquidIngredient>().enable();
        }
    }
    public void updateKitchenElements(int day)
    {
        switch (day)
        {
            case 0:
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                tablet.SetActive(false);
                break;
            case 1:
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                tablet.SetActive(true);
                break;
        }

    }

}