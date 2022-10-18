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
    private const int updateLiquid = 5; // mas grande = mas lento
    private float quantity; // porcentaje
    private Vector3 sliderPointInitPos;
    private RectTransform rt;
    public float[] liquids;
    public float[] liquidObjective;
    private const int maxLiquids = 3;

    /// Clock
    [SerializeField] Clock timer;

    void Start()
    {
        preparing = new int[SIZE];
        objective = new int[SIZE];

        liquids = new float[maxLiquids];
        liquidObjective = new float[maxLiquids];

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
    public bool comprobateIngredients()
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
        timer.stop();
        sliderBar.SetActive(false);
        dialogController.goMain();
        if (comprobateIngredients() && comprobateLiquids())
        {
            if (timer.comprobateTimer())
            {
                dialogController.correctResult();
            }
            else
            {
                dialogController.wrongResultTimer();
            }
        }
        else
        {
            dialogController.wrongResult();
        }
        resetFood();
    }
    public void cancelTask()
    {
        timer.stop();
        sliderBar.SetActive(false);
        dialogController.goMain();
        dialogController.cancelResult();
    }
    public void SetObjective(int[] ingredientTask, float[] liquidTask)
    {
        for (int i = 0; i < SIZE; i++) {
            objective[i] = ingredientTask[i];
        }
        for (int i = 0; i < maxLiquids; i++)
        {
            liquidObjective[i] = liquidTask[i];
        }
        timer.resetTimer();
        timer.start();
    }
    public void resetFood()
    {
        for (int i = 0; i < top; i++)
        {
            preparing[i] = 0;
        }
        top = 0;
        resetLiquid();
    }

    /////////////////////////////////////////////
    public void enableGameLiquid()
    {
        sliderBar.SetActive(true);
    }

    public void disableGameLiquid()
    {
        sliderBar.SetActive(false);
    }
    public void dropLiquid(int liquidType)
    {
        if (quantity <= 100)
        {
            sliderPoint.gameObject.transform.position += new Vector3(0, max / updateLiquid * Time.deltaTime);
            quantity += (max / updateLiquid) * Time.deltaTime * 100 / max;

            liquids[liquidType] += (max / updateLiquid) * Time.deltaTime * 100 / max;
        }
    }
    public void resetLiquid()
    {
        quantity = 0;
        for (int i = 0; i < maxLiquids; i++)
        {
            liquids[i] = 0;
        }
        sliderPoint.transform.position = sliderPointInitPos;
    }
    private bool comprobateLiquids()
    {
        for(int i = 0; i < maxLiquids; i++)
        {
            if(!((liquids[i] < (liquidObjective[i] + 5)) && (liquids[i] > (liquidObjective[i] - 5))))
            {
                return false;
            }
        }
        return true;
    }
}
