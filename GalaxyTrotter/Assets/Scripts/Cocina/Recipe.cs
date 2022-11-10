using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Recipe : MonoBehaviour
{
    [SerializeField] recipeName receta;
    private const int MAXINGREDIENTS = 10;
    private const int MAXLIQUIDS = 3;

    public int[] ingredientRecipe;
    public float[] liquidRecipe;
    enum recipeName { TonightPlease, SpecialUSI, AXXHole, CloudBomb, Unlucky, TheVisitor, H2O, StrawberryMoon, Kaua}

    void Start()
    {
        ingredientRecipe = new int[MAXINGREDIENTS];
        liquidRecipe = new float[MAXLIQUIDS];
        switch (receta)
        {
            case recipeName.TonightPlease:
                liquidRecipe[1] = 70;
                ingredientRecipe[0] = 2;
                ingredientRecipe[1] = 2;
                break;
            case recipeName.CloudBomb:
                liquidRecipe[0] = 70;
                liquidRecipe[1] = 30;
                break;
            case recipeName.Unlucky:
                liquidRecipe[1] = 60;
                ingredientRecipe[0] = 1;
                ingredientRecipe[1] = 2;
                ingredientRecipe[2] = 2;
                ingredientRecipe[3] = 3;
                ingredientRecipe[4] = 3;
                ingredientRecipe[5] = 3;
                ingredientRecipe[6] = 3;
                ingredientRecipe[7] = 3;
                break;
            case recipeName.AXXHole:
                liquidRecipe[0] = 50;
                ingredientRecipe[0] = 4;
                ingredientRecipe[1] = 2;
                ingredientRecipe[2] = 2;
                break;
            default:
                break;
        }
    }
}
