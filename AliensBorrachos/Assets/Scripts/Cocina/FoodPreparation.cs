using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodPreparation : MonoBehaviour
{
    [SerializeField] DialogController dialogController;

    private const int SIZE = 5;
    public int[] preparing;
    public int[] objective;
    private int top = 0;

    /// LiquidIngredients
    [SerializeField] GameObject sliderBar;
    [SerializeField] GameObject sliderPoint;
    private float max;
    private const int updateLiquid = 700;
    private float quantity;
    private Vector3 sliderPointInitPos;
    private RectTransform rt;

    void Start()
    {
        preparing = new int[SIZE];
        objective = new int[SIZE];

        rt = sliderBar.GetComponent<RectTransform>();
        max = rt.rect.height;
        quantity = 0;
        sliderPointInitPos = sliderPoint.transform.position;
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
            if (correctUnit == false)
            {
                correct = false;
            }
            i++;
            j = 0;
            correctUnit = false;
        }
        return correct;
    }
    public void preparationResult()
    {
        dialogController.goMain();
        if (prepareFood())
        {
            dialogController.correctResult();
        }
        else
        {
            dialogController.wrongResult();
        }
    }
    public void SetObjective(int[] task)
    {
        for (int i = 0; i < SIZE; i++) {
            objective[i] = task[i];
        }
    }
    public void resetFood()
    {
        for (int i = 0; i < top; i++)
        {
            preparing[i] = 0;
        }
        top = 0;
    }

    /////////////////////////////////////////////

    public void enableGame()
    {
        sliderBar.SetActive(true);
        sliderPoint.SetActive(true);
    }

    public void disableGame()
    {
        sliderBar.SetActive(false);
        sliderPoint.SetActive(false);
    }
    public void dropLiquid(int liquidType)
    {
        if (quantity <= 100)
        {
            sliderPoint.gameObject.transform.position += new Vector3(0, max / updateLiquid);
            quantity += (max / updateLiquid) * 100 / max;
        }
    }
    public void resetLiquid()
    {
        quantity = 0;
        sliderPoint.transform.position = sliderPointInitPos;
    }
}
