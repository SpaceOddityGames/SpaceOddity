using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPreparation : MonoBehaviour
{
    private const int SIZE = 5;
    public int[] preparing;
    public int[] objective;
    private int top = 0;
    
    void Start()
    {
        preparing = new int[SIZE];
        objective = new int[SIZE];
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
    public bool prepareFood()
    {
        int[] aux = new int[SIZE];
        for (int m = 0; m < SIZE; m++)
        {
            aux[m] = objective[m];
        }
        bool correct = true;
        bool correctUnit = false;
        int i = 0;
        int j = 0;
        while (i < SIZE && correct)
        {
            while (j < SIZE && !correctUnit) { 
                if (preparing[i] == aux[j])
                {
                    correctUnit = true;
                    aux[j] = -1;
                }
                j++;
            }
            if(correctUnit == false)
            {
                correct = false;
            }
            i++;
            j = 0;
            correctUnit = false;
        }
        return correct;
    }
    public void SetObjective(int[] task)
    {
        for (int i = 0; i < SIZE; i++){
            objective[i] = task[i];
        }
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
