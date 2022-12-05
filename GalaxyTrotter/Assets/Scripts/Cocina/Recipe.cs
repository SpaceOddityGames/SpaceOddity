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
    public string nameRecipe;
    enum recipeName { TonightPlease, SpecialUSI, AXXHole, CloudBomb, Unlucky, TheVisitor, H2O, StrawberryMoon, Kaua}

    void Start()
    {
        ingredientRecipe = new int[MAXINGREDIENTS];
        liquidRecipe = new float[MAXLIQUIDS];
        switch (receta)
        {
            case recipeName.TonightPlease:
                nameRecipe = "Tonight Please";
                liquidRecipe[1] = 70;
                ingredientRecipe[0] = 1;
                ingredientRecipe[1] = 1;
                break;
            case recipeName.SpecialUSI:
                nameRecipe = "Special USI";
                liquidRecipe[1] = 90;
                ingredientRecipe[0] = 2;
                ingredientRecipe[1] = 2;
                ingredientRecipe[2] = 3;
                break;
            case recipeName.AXXHole:
                nameRecipe = "AXXHole";
                liquidRecipe[0] = 50;
                ingredientRecipe[0] = 4;
                ingredientRecipe[1] = 5;
                ingredientRecipe[2] = 5;
                break;
            case recipeName.CloudBomb:
                nameRecipe = "CloudBomb";
                liquidRecipe[0] = 70;
                liquidRecipe[1] = 30;
                break;
            case recipeName.Unlucky:
                nameRecipe = "Unlucky";
                liquidRecipe[0] = 60;
                ingredientRecipe[0] = 1;
                ingredientRecipe[1] = 1;
                ingredientRecipe[2] = 1;
                ingredientRecipe[3] = 6;
                ingredientRecipe[4] = 6;
                ingredientRecipe[5] = 5;
                break;
            case recipeName.TheVisitor:
                nameRecipe = "The Visitor";
                liquidRecipe[1] = 70;
                ingredientRecipe[0] = 2;
                ingredientRecipe[1] = 2;
                ingredientRecipe[2] = 2;
                ingredientRecipe[3] = 7;
                break;
            case recipeName.H2O:
                nameRecipe = "H2O";
                liquidRecipe[1] = 60;
                ingredientRecipe[0] = 4;
                ingredientRecipe[1] = 4;
                ingredientRecipe[2] = 4;
                ingredientRecipe[3] = 7;
                ingredientRecipe[4] = 8;
                ingredientRecipe[5] = 8;
                break;
            case recipeName.StrawberryMoon:
                nameRecipe = "Strawberry Moon";
                liquidRecipe[2] = 50;
                ingredientRecipe[0] = 1;
                ingredientRecipe[1] = 1;
                ingredientRecipe[2] = 2;
                ingredientRecipe[3] = 2;
                ingredientRecipe[4] = 2;
                ingredientRecipe[5] = 6;
                break;
            case recipeName.Kaua:
                nameRecipe = "Kaua";
                liquidRecipe[1] = 40;
                liquidRecipe[2] = 20;
                ingredientRecipe[0] = 3;
                ingredientRecipe[1] = 5;
                ingredientRecipe[2] = 5;
                ingredientRecipe[3] = 5;
                ingredientRecipe[4] = 8;
                ingredientRecipe[5] = 8;
                ingredientRecipe[6] = 8;
                ingredientRecipe[7] = 8;
                break;
        }
    }
}
