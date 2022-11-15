using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodPreparation : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] DialogController dialogController;
    [SerializeField] TutorialManager tutorialManager;

    private const int SIZE = 10;
    public int[] preparing;
    public int[] objective;
    private int top = 0;
    [SerializeField] public FoodPreparation foodPreparator2;
    /// LiquidIngredients
    [SerializeField] GameObject kitchenCanvas;
    [SerializeField] GameObject sliderBar;
    [SerializeField] GameObject sliderPointInit;
    [SerializeField] GameObject bordeRelleno;
    [SerializeField] GameObject relleno;
    [SerializeField] GameObject[] sliderFills;
    
    private float max; //liquid drop max tamaño
    private const int updateLiquid = 5; // mas grande = mas lento
    public float quantityP; // porcentaje
    private float[] quantities;
    private RectTransform rt;
    public float[] liquids;
    public float[] liquidObjective;
    [SerializeField] Canvas canvas;
    private const int maxLiquids = 3;
    //Alfas
    private float t1 = 0;
    private float t2 = 0;
    private float t3 = 0;
    [HideInInspector] public bool alfaUp = false;
    [HideInInspector] public bool alfaDown = false;

    /// Clock
    [SerializeField] Clock timer;
    //two tasks
    private bool twoTask = false; // true = two preparations
    //tutorial
    [HideInInspector] public bool tutorial = false;
    [HideInInspector] public bool tutorialIngredient = false;
    //
    [HideInInspector] public bool reseted = false;
    //Comprobaciones varias
    [HideInInspector] public bool comprobatePimkyu = false;
    [HideInInspector] public bool reject = false;
    [HideInInspector] public int servedPimkyu = 0;
    [HideInInspector] public bool analizeLerman = false;
    [HideInInspector] public bool lermanEnvenenado = false;
    [HideInInspector] public bool lermanDouble = false;
    [HideInInspector] public bool comprobateChip = false;

    void Start()
    {
        preparing = new int[SIZE];
        objective = new int[SIZE];

        liquids = new float[maxLiquids];
        liquidObjective = new float[maxLiquids];
        quantities= new float[maxLiquids];

        rt = sliderBar.GetComponent<RectTransform>();
        max = rt.rect.height;
        quantityP = 0;
    }

    //Se llama a la función desde los ingredientes
    public void addIngredient(int foodType)
    {

        if (top < SIZE)
        {
            preparing[top] = foodType;
            top++;
        }
        if (tutorialIngredient)
        {
            tutorialManager.nextText();
        }
    }
    //Comprueba la correcta preparación de la comida
    public bool comprobateIngredients()
    {
        if (analizeLerman)
        {
            bool hasMoonso = false;
            for (int k = 0; k < SIZE; k++)
            {
                if (preparing[k] == 9)
                {
                    hasMoonso = true;
                    preparing[k] = 0;
                }
                if (hasMoonso)
                {
                    lermanEnvenenado = true;
                    if (gameManager.h01)
                    {
                        gameManager.h06 = true;
                    }
                    else
                    {
                        gameManager.h05 = true;
                    }
                }
                else
                {
                    gameManager.h06 = false;
                }
            }
            int odziaQuantity = 0;
            for (int k = 0; k < SIZE; k++)
            {
                if (preparing[k] == 3)
                {
                    odziaQuantity++;
                    if (odziaQuantity == 2)
                    {
                        preparing[k] = 0;
                    }
                }
            }
            if(odziaQuantity == 2)
            {
                lermanDouble = true;
            }
            if(odziaQuantity != 3 && !hasMoonso)
            {
                gameManager.h08 = true;
            }
        }
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
        if (comprobatePimkyu)
        {
            bool hasPimkyu = false;
            for(int k = 0; k < SIZE; k++)
            {
                if(preparing[k] == 3)
                {
                    hasPimkyu = true;
                }
            }
            if (hasPimkyu)
            {
                servedPimkyu++;
                if (foodPreparator2 != null)
                {
                    foodPreparator2.servedPimkyu++;
                }
            }
            if (servedPimkyu >= 2)
            {
                reject = true;
            }
        }
        return correct;
    }
        
    public void preparationResult()
    {
        timer.stop();
        kitchenCanvas.SetActive(false);
        dialogController.goMain();
        if (tutorial)
        {
            tutorial = false;
            tutorialManager.endTutorial();
            dialogController.correctResult(true);
            resetFood();
            return;
        }
        if (comprobateChip)
        {
            bool hasChip = false;
            for (int k = 0; k < SIZE; k++)
            {
                if (preparing[k] == 3)
                {
                    hasChip = true;
                }
            }
            if (hasChip)
            {
                if (!gameManager.h06)
                {
                    gameManager.h05 = true;
                    dialogController.resultChip();
                    return;
                }
                if(gameManager.h06)
                {
                    gameManager.h02 = true;
                }
            }
            if (!hasChip)
            {
                gameManager.h03 = true;
            }
        }
        if (comprobateIngredients() && comprobateLiquids())
        {
            if (timer.comprobateTimer())
            {
                if (twoTask)
                {
                    if(foodPreparator2.comprobateIngredients() && foodPreparator2.comprobateLiquids())
                    {
                        dialogController.correctResult(reseted);
                    }
                    else
                    {
                        dialogController.wrongResult();
                    }
                }
                else
                {
                    dialogController.correctResult(reseted);
                }
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
        kitchenCanvas.SetActive(false);
        dialogController.goMain();
        dialogController.cancelResult();
        resetFood();
    }
    public void SetObjective(int[] ingredientTask, float[] liquidTask)
    {
        reject = false;
        reseted = false;
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
        if (twoTask)
        {
            foodPreparator2.resetFood();
        }
    }

    /////////////////////////////////////////////
    public void enableGameLiquid()
    {
        kitchenCanvas.SetActive(true);
    }

    public void disableGameLiquid()
    {
        kitchenCanvas.SetActive(false);
    }
    public void dropLiquid(int liquidType)
    {
        if (quantityP < 100)
        {
            quantityP += (max / updateLiquid) * Time.deltaTime * 100 / max;
            liquids[liquidType] += (max / updateLiquid) * Time.deltaTime * 100 / max;
            quantities[liquidType] += max / updateLiquid * Time.deltaTime;
            RectTransform rs = sliderFills[liquidType].GetComponent<RectTransform>();
            sliderFills[liquidType].transform.position += new Vector3(0, max / updateLiquid * Time.deltaTime / 2 * canvas.scaleFactor);
            for(int i = liquidType+1; i < sliderFills.Length; i++)
            {
                sliderFills[i].transform.position += new Vector3(0, max / updateLiquid * Time.deltaTime / 2 * 2 * canvas.scaleFactor);
            }
            rs.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, quantities[liquidType]);
        }
    }
    public void resetLiquid()
    {
        quantityP = 0;
        for (int i = 0; i < maxLiquids; i++)
        {
            liquids[i] = 0;
        }
        for(int i = 0; i < sliderFills.Length; i++)
        {
            sliderFills[i].transform.position = sliderPointInit.transform.position;
            quantities[i] = 0;
            RectTransform rs = sliderFills[i].GetComponent<RectTransform>();
            rs.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
        }
    }
    public bool comprobateLiquids()
    {
        for(int i = 0; i < maxLiquids; i++)
        {
            if(!((liquids[i] < (liquidObjective[i] + 7)) && (liquids[i] > (liquidObjective[i] - 7))))
            {
                return false;
            }
        }
        return true;
    }
    
    public void liquidChangeAlfaUp()
    {
        t1 += Time.deltaTime / 0.5f;
        float startAlfa = sliderBar.GetComponent<Image>().color.a;
        float targetAlfa = 1;
        float targetAlfaBars = 0.6f;
        float targetAlfaRelleno = 0.2f;
        float newAlfaBars = Mathf.Lerp(startAlfa, targetAlfaBars, t1); 
        float newAlfaRelleno = Mathf.Lerp(startAlfa, targetAlfaRelleno, t1);
        float newAlfa = Mathf.Lerp(startAlfa, targetAlfa, t1);
        Color newColor;
        //sliderBar
        newColor = sliderBar.GetComponent<Image>().color;
        newColor.a = newAlfa;
        sliderBar.GetComponent<Image>().color = newColor;
        //sliderFills
        newColor = bordeRelleno.GetComponent<Image>().color;
        newColor.a = newAlfa;
        bordeRelleno.GetComponent<Image>().color = newColor;
        //
        newColor = relleno.GetComponent<Image>().color;
        newColor.a = newAlfaRelleno;
        relleno.GetComponent<Image>().color = newColor;
        for (int i = 0; i < sliderFills.Length; i++){

            newColor = sliderFills[i].GetComponent<Image>().color;
            newColor.a = newAlfaBars;
            sliderFills[i].GetComponent<Image>().color = newColor;
        }
        if (t1 > 1)
        {
            alfaUp = false;
        }
    }
    public void liquidChangeAlfaDown()
    {
        if (alfaDown)
        {
            t2 += Time.deltaTime / 2f;
            if (t2 > 1f)
            {
                t3 += Time.deltaTime / 4f;
                float startAlfa = sliderBar.GetComponent<Image>().color.a;
                float startAlfaBars = sliderFills[0].GetComponent<Image>().color.a;
                float startAlfaRelleno = relleno.GetComponent<Image>().color.a;
                float targetAlfa = 0;
                float newAlfa = Mathf.Lerp(startAlfa, targetAlfa, t3);
                float newAlfaBars = Mathf.Lerp(startAlfaBars, targetAlfa, t3);
                float newAlfaRelleno = Mathf.Lerp(startAlfaRelleno, targetAlfa, t3);
                Color newColor;
                //sliderBar
                newColor = sliderBar.GetComponent<Image>().color;
                newColor.a = newAlfa;
                sliderBar.GetComponent<Image>().color = newColor;
                //sliderFills
                newColor = bordeRelleno.GetComponent<Image>().color;
                newColor.a = newAlfa;
                bordeRelleno.GetComponent<Image>().color = newColor;
                //
                newColor = relleno.GetComponent<Image>().color;
                newColor.a = newAlfaRelleno;
                relleno.GetComponent<Image>().color = newColor;
                for (int i = 0; i < sliderFills.Length; i++)
                {

                    newColor = sliderFills[i].GetComponent<Image>().color;
                    newColor.a = newAlfaBars;
                    sliderFills[i].GetComponent<Image>().color = newColor;
                }
            }
            if (t3 > 1f)
            {
                alfaDown = false;
                t2 = 0;
                t3 = 0;
            }
        }
    }
    private void Update()
    {
        if (alfaUp)
        {
            liquidChangeAlfaUp();
            t2 = 0;
            t3 = 0;
        }
        else
        {
            liquidChangeAlfaDown();
        }
    }
    public void SetTwoTasks(bool value)
    {
        twoTask = value;
    }
}
