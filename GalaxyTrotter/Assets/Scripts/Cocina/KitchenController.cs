using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{
    [SerializeField] FoodPreparation foodpreparator;
    [SerializeField] GameObject[] ingredients;
    [SerializeField] GameObject[] liquidIngredients;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] recipes;
    [SerializeField] GameObject[] normas;
    [SerializeField] GameObject[] ingredientesTablet;
    [SerializeField] GameObject[] alertas;
    [SerializeField] PostitButton postit;
    [SerializeField] TabletButton tablet1;
    [SerializeField] TabletButtonBar tablet2;
    [SerializeField] GameObject barNormal;
    [SerializeField] GameObject barUSI;
    [SerializeField] GameObject cocinaNormal;
    [SerializeField] GameObject cocinaUSI;
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
    public void pauseGame()
    {
        foreach (GameObject ingredient in ingredients)
        {
            ingredient.GetComponent<Ingredient>().pause();
        }
        foreach (GameObject liquidIngredient in liquidIngredients)
        {
            liquidIngredient.GetComponent<LiquidIngredient>().pause();
        }
        postit.paused = true;
        tablet1.paused = true;
        tablet2.paused = true;
    }
    public void resumeGame()
    {
        foreach (GameObject ingredient in ingredients)
        {
            ingredient.GetComponent<Ingredient>().resume();
        }
        foreach (GameObject liquidIngredient in liquidIngredients)
        {
            liquidIngredient.GetComponent<LiquidIngredient>().resume();
        }
        postit.paused = false;
        tablet1.paused = false;
        tablet2.paused = false;
    }
    public void updateKitchenElements(int day)
    {
        foodpreparator.servedPimkyu = 0;
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
                ingredients[8].SetActive(false);
                ingredients[9].SetActive(false);
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
                //normas
                normas[0].SetActive(true);
                normas[1].SetActive(false);
                normas[2].SetActive(false);
                normas[3].SetActive(false);
                foodpreparator.comprobatePimkyu = false;
                //IngredientesTablet
                ingredientesTablet[0].SetActive(true);
                ingredientesTablet[1].SetActive(true);
                ingredientesTablet[2].SetActive(true);
                ingredientesTablet[3].SetActive(true);
                ingredientesTablet[4].SetActive(true);
                ingredientesTablet[5].SetActive(false);
                ingredientesTablet[6].SetActive(false);
                ingredientesTablet[7].SetActive(false);
                ingredientesTablet[8].SetActive(false);
                ingredientesTablet[9].SetActive(true);
                ingredientesTablet[10].SetActive(true);
                ingredientesTablet[11].SetActive(false);
                //Alertas
                alertas[0].SetActive(false);
                alertas[1].SetActive(false);
                alertas[2].SetActive(false);
                alertas[3].SetActive(false);
                //ModeladoBarKitchen
                barNormal.SetActive(true);
                barUSI.SetActive(false);
                cocinaNormal.SetActive(true);
                cocinaUSI.SetActive(false);
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
                ingredients[8].SetActive(false);
                ingredients[9].SetActive(false);
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
                //normas
                normas[0].SetActive(true);
                normas[1].SetActive(false);
                normas[2].SetActive(false);
                normas[3].SetActive(false);
                foodpreparator.comprobatePimkyu = false;
                //IngredientesTablet
                ingredientesTablet[0].SetActive(true);
                ingredientesTablet[1].SetActive(true);
                ingredientesTablet[2].SetActive(true);
                ingredientesTablet[3].SetActive(true);
                ingredientesTablet[4].SetActive(true);
                ingredientesTablet[5].SetActive(false);
                ingredientesTablet[6].SetActive(false);
                ingredientesTablet[7].SetActive(false);
                ingredientesTablet[8].SetActive(false);
                ingredientesTablet[9].SetActive(true);
                ingredientesTablet[10].SetActive(true);
                ingredientesTablet[11].SetActive(false);
                //Alertas
                alertas[0].SetActive(true);
                alertas[1].SetActive(false);
                alertas[2].SetActive(true);
                alertas[3].SetActive(true);
                //ModeladoBarKitchen
                barNormal.SetActive(true);
                barUSI.SetActive(false);
                cocinaNormal.SetActive(true);
                cocinaUSI.SetActive(false);
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
                ingredients[8].SetActive(false);
                ingredients[9].SetActive(false);
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
                //normas
                normas[0].SetActive(true);
                normas[1].SetActive(true);
                normas[2].SetActive(false);
                normas[3].SetActive(false);
                foodpreparator.comprobatePimkyu = true;
                //IngredientesTablet
                ingredientesTablet[0].SetActive(true);
                ingredientesTablet[1].SetActive(true);
                ingredientesTablet[2].SetActive(true);
                ingredientesTablet[3].SetActive(true);
                ingredientesTablet[4].SetActive(true);
                ingredientesTablet[5].SetActive(true);
                ingredientesTablet[6].SetActive(true);
                ingredientesTablet[7].SetActive(false);
                ingredientesTablet[8].SetActive(false);
                ingredientesTablet[9].SetActive(true);
                ingredientesTablet[10].SetActive(true);
                ingredientesTablet[11].SetActive(false);
                //Alertas
                alertas[0].SetActive(true);
                alertas[1].SetActive(true);
                alertas[2].SetActive(true);
                //ModeladoBarKitchen
                barNormal.SetActive(true);
                barUSI.SetActive(false);
                cocinaNormal.SetActive(true);
                cocinaUSI.SetActive(false);
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
                ingredients[8].SetActive(false);
                ingredients[9].SetActive(false);
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
                //normas
                normas[0].SetActive(true);
                normas[1].SetActive(true);
                normas[2].SetActive(true);
                normas[3].SetActive(false);
                foodpreparator.comprobatePimkyu = true;
                //IngredientesTablet
                ingredientesTablet[0].SetActive(true);
                ingredientesTablet[1].SetActive(true);
                ingredientesTablet[2].SetActive(true);
                ingredientesTablet[3].SetActive(true);
                ingredientesTablet[4].SetActive(true);
                ingredientesTablet[5].SetActive(true);
                ingredientesTablet[6].SetActive(true);
                ingredientesTablet[7].SetActive(true);
                ingredientesTablet[8].SetActive(false);
                ingredientesTablet[9].SetActive(true);
                ingredientesTablet[10].SetActive(true);
                ingredientesTablet[11].SetActive(false);
                //Alertas
                alertas[0].SetActive(true);
                alertas[1].SetActive(true);
                alertas[2].SetActive(true);
                //ModeladoBarKitchen
                barNormal.SetActive(true);
                barUSI.SetActive(false);
                cocinaNormal.SetActive(true);
                cocinaUSI.SetActive(false);
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
                ingredients[8].SetActive(false);
                ingredients[9].SetActive(false);
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
                //normas
                normas[0].SetActive(true);
                normas[1].SetActive(true);
                normas[2].SetActive(false);
                normas[3].SetActive(false);
                foodpreparator.comprobatePimkyu = true;
                //IngredientesTablet
                ingredientesTablet[0].SetActive(true);
                ingredientesTablet[1].SetActive(true);
                ingredientesTablet[2].SetActive(true);
                ingredientesTablet[3].SetActive(true);
                ingredientesTablet[4].SetActive(true);
                ingredientesTablet[5].SetActive(true);
                ingredientesTablet[6].SetActive(true);
                ingredientesTablet[7].SetActive(true);
                ingredientesTablet[8].SetActive(false);
                ingredientesTablet[9].SetActive(true);
                ingredientesTablet[10].SetActive(true);
                ingredientesTablet[11].SetActive(true);
                //Alertas
                alertas[0].SetActive(true);
                alertas[1].SetActive(true);
                alertas[2].SetActive(true);
                //ModeladoBarKitchen
                barNormal.SetActive(true);
                barUSI.SetActive(false);
                cocinaNormal.SetActive(true);
                cocinaUSI.SetActive(false);
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
                ingredients[8].SetActive(true);
                ingredients[9].SetActive(false);
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
                //normas
                normas[0].SetActive(true);
                normas[1].SetActive(true);
                normas[2].SetActive(false);
                normas[3].SetActive(true);
                foodpreparator.comprobatePimkyu = true;
                //IngredientesTablet
                ingredientesTablet[0].SetActive(true);
                ingredientesTablet[1].SetActive(true);
                ingredientesTablet[2].SetActive(true);
                ingredientesTablet[3].SetActive(true);
                ingredientesTablet[4].SetActive(true);
                ingredientesTablet[5].SetActive(true);
                ingredientesTablet[6].SetActive(true);
                ingredientesTablet[7].SetActive(true);
                ingredientesTablet[8].SetActive(true);
                ingredientesTablet[9].SetActive(true);
                ingredientesTablet[10].SetActive(true);
                ingredientesTablet[11].SetActive(true);
                //Alertas
                alertas[0].SetActive(true);
                alertas[1].SetActive(true);
                alertas[2].SetActive(false);
                //ModeladoBarKitchen
                barNormal.SetActive(false);
                barUSI.SetActive(true);
                cocinaNormal.SetActive(false);
                cocinaUSI.SetActive(true);
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
                ingredients[8].SetActive(false);
                ingredients[9].SetActive(false);
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
                //normas
                normas[0].SetActive(true);
                normas[1].SetActive(true);
                normas[2].SetActive(false);
                normas[3].SetActive(true);
                foodpreparator.comprobatePimkyu = true;
                //IngredientesTablet
                ingredientesTablet[0].SetActive(true);
                ingredientesTablet[1].SetActive(true);
                ingredientesTablet[2].SetActive(true);
                ingredientesTablet[3].SetActive(true);
                ingredientesTablet[4].SetActive(true);
                ingredientesTablet[5].SetActive(true);
                ingredientesTablet[6].SetActive(true);
                ingredientesTablet[7].SetActive(true);
                ingredientesTablet[8].SetActive(true);
                ingredientesTablet[9].SetActive(true);
                ingredientesTablet[10].SetActive(true);
                ingredientesTablet[11].SetActive(true);
                //Alertas
                alertas[0].SetActive(false);
                alertas[1].SetActive(false);
                alertas[2].SetActive(false);
                //ModeladoBarKitchen
                barNormal.SetActive(false);
                barUSI.SetActive(true);
                cocinaNormal.SetActive(false);
                cocinaUSI.SetActive(true);
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
                ingredients[8].SetActive(false);
                ingredients[9].SetActive(true);
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
                //normas
                normas[0].SetActive(true);
                normas[1].SetActive(true);
                normas[2].SetActive(false);
                normas[3].SetActive(true);
                foodpreparator.comprobatePimkyu = true;
                //IngredientesTablet
                ingredientesTablet[0].SetActive(true);
                ingredientesTablet[1].SetActive(true);
                ingredientesTablet[2].SetActive(true);
                ingredientesTablet[3].SetActive(true);
                ingredientesTablet[4].SetActive(true);
                ingredientesTablet[5].SetActive(true);
                ingredientesTablet[6].SetActive(true);
                ingredientesTablet[7].SetActive(true);
                ingredientesTablet[8].SetActive(true);
                ingredientesTablet[9].SetActive(true);
                ingredientesTablet[10].SetActive(true);
                ingredientesTablet[11].SetActive(true);
                //Alertas
                alertas[0].SetActive(false);
                alertas[1].SetActive(false);
                alertas[2].SetActive(false);
                //ModeladoBarKitchen
                barNormal.SetActive(false);
                barUSI.SetActive(true);
                cocinaNormal.SetActive(false);
                cocinaUSI.SetActive(true);
                break;
        }

    }

}