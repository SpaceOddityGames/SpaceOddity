using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPreparation : MonoBehaviour
{
    public int[] preparing;
    private int top = 0;
    
    void Start()
    {
        preparing = new int[5];
    }

    //Se llama a la función desde los ingredientes
    public void addIngredient(int foodType)
    {
        preparing[top] = foodType;
        top++;
    }
    //Comprueba la correcta preparación de la comida
    private void prepareFood()
    {

    }
}
