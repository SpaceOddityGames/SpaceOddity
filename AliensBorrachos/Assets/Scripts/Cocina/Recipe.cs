using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Recipe : MonoBehaviour
{
    [SerializeField] recipeName receta;
    private const int MAXINGREDIENTS = 5;
    private const int MAXLIQUIDS = 3;

    public int[] ingredientRecipe;
    public float[] liquidRecipe;
    enum recipeName { TonightPlease, chocolate, yogur}

    void Start()
    {
        ingredientRecipe = new int[MAXINGREDIENTS];
        liquidRecipe = new float[MAXLIQUIDS];
        switch (receta)
        {
            case recipeName.TonightPlease:
                ingredientRecipe[0] = 1;
                ingredientRecipe[1] = 1;
                liquidRecipe[0] = 70;
                break;
            case recipeName.chocolate:
                ingredientRecipe[0] = 1;
                ingredientRecipe[1] = 1;
                liquidRecipe[1] = 40;
                liquidRecipe[2] = 20;
                break;
            default:
                break;
        }
    }
}
