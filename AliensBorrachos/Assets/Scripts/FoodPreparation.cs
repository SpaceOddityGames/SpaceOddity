using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPreparation : MonoBehaviour
{
    private const int SIZE = 5;
    public int[] preparing;
    private int top = 0;
    
    void Start()
    {
        preparing = new int[SIZE];
    }

    //Se llama a la función desde los ingredientes
    public void addIngredient(int foodType)
    {
        if (top < SIZE)
        {
            preparing[top] = foodType;
            top++;
        }
    }
    //Comprueba la correcta preparación de la comida
    public void prepareFood()
    {

    }
    public void resetFood()
    {
        for(int i = 0; i < top; i++)
        {
            preparing[i] = 0;
        }
        top = 0;
    }
}
