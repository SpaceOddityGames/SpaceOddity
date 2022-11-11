using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{
    [SerializeField] GameObject[] ingredients;
    [SerializeField] GameObject[] liquidIngredients;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] recipes;
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
                //ingredientes
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                ingredients[4].SetActive(true);
                ingredients[5].SetActive(false);
                ingredients[6].SetActive(false);
                ingredients[7].SetActive(false);
                //ingredientesLiquidos
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                liquidIngredients[2].SetActive(false);
                //botones
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                //recipes
                recipes[0].SetActive(true);
                recipes[1].SetActive(true);
                recipes[2].SetActive(true);
                recipes[3].SetActive(false);
                recipes[4].SetActive(false);
                recipes[5].SetActive(false);
                recipes[6].SetActive(false);
                recipes[7].SetActive(false);
                recipes[8].SetActive(false);
                break;
            case 1:
                //ingredientes
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                ingredients[4].SetActive(true);
                ingredients[5].SetActive(false);
                ingredients[6].SetActive(false);
                ingredients[7].SetActive(false);
                //ingredientesLiquidos
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                liquidIngredients[2].SetActive(false);
                //botones
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                //recipes
                recipes[0].SetActive(true);
                recipes[1].SetActive(true);
                recipes[2].SetActive(true);
                recipes[3].SetActive(true);
                recipes[4].SetActive(false);
                recipes[5].SetActive(false);
                recipes[6].SetActive(false);
                recipes[7].SetActive(false);
                recipes[8].SetActive(false);
                break;
            case 2:
                //ingredientes
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                ingredients[4].SetActive(true);
                ingredients[5].SetActive(true);
                ingredients[6].SetActive(true);
                ingredients[7].SetActive(false);
                //ingredientesLiquidos
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                liquidIngredients[2].SetActive(false);
                //botones
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                //recipes
                recipes[0].SetActive(true);
                recipes[1].SetActive(true);
                recipes[2].SetActive(true);
                recipes[3].SetActive(true);
                recipes[4].SetActive(true);
                recipes[5].SetActive(true);
                recipes[6].SetActive(false);
                recipes[7].SetActive(false);
                recipes[8].SetActive(false);
                break;
            case 3:
                //ingredientes
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                ingredients[4].SetActive(true);
                ingredients[5].SetActive(true);
                ingredients[6].SetActive(true);
                ingredients[7].SetActive(true);
                //ingredientesLiquidos
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                liquidIngredients[2].SetActive(false);
                //botones
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                //recipes
                recipes[0].SetActive(true);
                recipes[1].SetActive(true);
                recipes[2].SetActive(true);
                recipes[3].SetActive(true);
                recipes[4].SetActive(true);
                recipes[5].SetActive(true);
                recipes[6].SetActive(true);
                recipes[7].SetActive(false);
                recipes[8].SetActive(false);
                break;
            case 4:
                //ingredientes
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                ingredients[4].SetActive(true);
                ingredients[5].SetActive(true);
                ingredients[6].SetActive(true);
                ingredients[7].SetActive(true);
                //ingredientesLiquidos
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                liquidIngredients[2].SetActive(true);
                //botones
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                //recipes
                recipes[0].SetActive(true);
                recipes[1].SetActive(true);
                recipes[2].SetActive(true);
                recipes[3].SetActive(true);
                recipes[4].SetActive(true);
                recipes[5].SetActive(true);
                recipes[6].SetActive(true);
                recipes[7].SetActive(true);
                recipes[8].SetActive(true);
                break;
            case 5:
                //ingredientes
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                ingredients[4].SetActive(true);
                ingredients[5].SetActive(true);
                ingredients[6].SetActive(true);
                ingredients[7].SetActive(true);
                //ingredientesLiquidos
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                liquidIngredients[2].SetActive(true);
                //botones
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                //recipes
                recipes[0].SetActive(true);
                recipes[1].SetActive(true);
                recipes[2].SetActive(true);
                recipes[3].SetActive(true);
                recipes[4].SetActive(true);
                recipes[5].SetActive(true);
                recipes[6].SetActive(true);
                recipes[7].SetActive(true);
                recipes[8].SetActive(true);
                break;
            case 6:
                //ingredientes
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                ingredients[4].SetActive(true);
                ingredients[5].SetActive(true);
                ingredients[6].SetActive(true);
                ingredients[7].SetActive(true);
                //ingredientesLiquidos
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                liquidIngredients[2].SetActive(true);
                //botones
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                //recipes
                recipes[0].SetActive(true);
                recipes[1].SetActive(true);
                recipes[2].SetActive(true);
                recipes[3].SetActive(true);
                recipes[4].SetActive(true);
                recipes[5].SetActive(true);
                recipes[6].SetActive(true);
                recipes[7].SetActive(true);
                recipes[8].SetActive(true);
                break;
            case 7:
                //ingredientes
                ingredients[0].SetActive(true);
                ingredients[1].SetActive(true);
                ingredients[2].SetActive(true);
                ingredients[3].SetActive(true);
                ingredients[4].SetActive(true);
                ingredients[5].SetActive(true);
                ingredients[6].SetActive(true);
                ingredients[7].SetActive(true);
                //ingredientesLiquidos
                liquidIngredients[0].SetActive(true);
                liquidIngredients[1].SetActive(true);
                liquidIngredients[2].SetActive(true);
                //botones
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                //recipes
                recipes[0].SetActive(true);
                recipes[1].SetActive(true);
                recipes[2].SetActive(true);
                recipes[3].SetActive(true);
                recipes[4].SetActive(true);
                recipes[5].SetActive(true);
                recipes[6].SetActive(true);
                recipes[7].SetActive(true);
                recipes[8].SetActive(true);
                break;
        }

    }

}