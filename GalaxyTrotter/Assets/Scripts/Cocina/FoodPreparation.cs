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
    [SerializeField] GameObject hongustarTuto;

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
    [HideInInspector] public Recipe recipe1;
    [HideInInspector] public Recipe recipe2;
    [HideInInspector] public bool second = false;

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
            hongustarTuto.GetComponent<Ingredient>().enabled = false;
            tutorialIngredient = false;
            tutorialManager.nextText();
        }
    }
    //Comprueba la correcta preparación de la bebida
    public bool comprobateIngredients()
    {
        if (analizeLerman)
        {
            analizeLerman = false;
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
                        gameManager.h10 = true;
                    }
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
            if(odziaQuantity != 2 && !hasMoonso)
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
        if (twoTask)
        {
            while (i < SIZE && correct)
            {
                while (j < SIZE && !correctUnit)
                {
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
            if (correct)
            {
                second = false;
            }
            else
            {
                SetObjectiveBasic(recipe2.ingredientRecipe, recipe2.liquidRecipe);
                for (int m = 0; m < SIZE; m++)
                {
                    aux[m] = objective[m];
                }
                correct = true;
                correctUnit = false;
                i = 0;
                j = 0;
                while (i < SIZE && correct)
                {
                    while (j < SIZE && !correctUnit)
                    {
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
                if (correct)
                {
                    second = true;
                }
            }
        }
        if (!twoTask)
        {
            for (int m = 0; m < SIZE; m++)
            {
                aux[m] = objective[m];
            }
            correct = true;
            correctUnit = false;
            i = 0;
            j = 0;
            while (i < SIZE && correct)
            {
                while (j < SIZE && !correctUnit)
                {
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
        }
        if (comprobatePimkyu)
        {
            bool hasPimkyu = false;
            for(int k = 0; k < SIZE; k++)
            {
                if(preparing[k] == 2)
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
        }
        return correct;
    }
    private bool comprobateOnlyIng()
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
            while (j < SIZE && !correctUnit)
            {
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
        kitchenCanvas.SetActive(false);
        dialogController.goMain();
        if (tutorial)
        {
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
                if (preparing[k] == 10)
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
        if (comprobateIngredients() && comprobateLiquids() && !twoTask)
        {
            if (timer.comprobateTimer())
            {
                dialogController.correctResult(reseted);
            }
            else
            {
                FindObjectOfType<Historial>().addHistoryErrorTime();
                dialogController.wrongResultTimer();
            }
        }
        else if(!twoTask)
        {
            dialogController.wrongResult();
            if (!comprobateOnlyIng() && !comprobateLiquids())
            {
                FindObjectOfType<Historial>().addHistoryErrorIngAndLiq();
            }else if(!comprobateOnlyIng() && comprobateLiquids())
            {
                FindObjectOfType<Historial>().addHistoryErrorIng();
            }
            else if(comprobateOnlyIng() && !comprobateLiquids())
            {
                FindObjectOfType<Historial>().addHistoryErrorLiq();
            }
        }
        if (twoTask)
        {
            if (second)
            {
                foodPreparator2.SetObjectiveBasic(recipe1.ingredientRecipe, recipe1.liquidRecipe);
            }
            else
            {
                foodPreparator2.SetObjectiveBasic(recipe2.ingredientRecipe, recipe2.liquidRecipe);
            }
            
            if (comprobateIngredients())
            {
                if (comprobateLiquids())
                {
                    if (timer.comprobateTimer())
                    {
                        if (foodPreparator2.comprobateIngredients() && foodPreparator2.comprobateLiquids())
                        {
                            bool res = reseted;
                            if (reseted || foodPreparator2.reseted)
                            {
                                res = true;
                            }
                            dialogController.correctResult(res);
                        }
                        else
                        {
                            dialogController.wrongResult();
                            if (!foodPreparator2.comprobateOnlyIng() && !foodPreparator2.comprobateLiquids())
                            {
                                FindObjectOfType<Historial>().addHistoryErrorIngAndLiq();
                            }
                            else if (!foodPreparator2.comprobateOnlyIng() && foodPreparator2.comprobateLiquids())
                            {
                                FindObjectOfType<Historial>().addHistoryErrorIng();
                            }
                            else if (foodPreparator2.comprobateOnlyIng() && !foodPreparator2.comprobateLiquids())
                            {
                                FindObjectOfType<Historial>().addHistoryErrorLiq();
                            }
                        }
                    }
                    else
                    {
                        FindObjectOfType<Historial>().addHistoryErrorTime();
                        dialogController.wrongResultTimer();
                    }
                }
                else
                {
                    dialogController.wrongResult();
                    if (!comprobateOnlyIng() && !comprobateLiquids())
                    {
                        FindObjectOfType<Historial>().addHistoryErrorIngAndLiq();
                    }
                    else if (!comprobateOnlyIng() && comprobateLiquids())
                    {
                        FindObjectOfType<Historial>().addHistoryErrorIng();
                    }
                    else if (comprobateOnlyIng() && !comprobateLiquids())
                    {
                        FindObjectOfType<Historial>().addHistoryErrorLiq();
                    }
                }
            }
            else
            {
                dialogController.wrongResult();
                if (!comprobateOnlyIng() && !comprobateLiquids())
                {
                    FindObjectOfType<Historial>().addHistoryErrorIngAndLiq();
                }
                else if (!comprobateOnlyIng() && comprobateLiquids())
                {
                    FindObjectOfType<Historial>().addHistoryErrorIng();
                }
                else if (comprobateOnlyIng() && !comprobateLiquids())
                {
                    FindObjectOfType<Historial>().addHistoryErrorLiq();
                }
            }
            
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
        objective = new int[SIZE];
        liquidObjective = new float[maxLiquids];
        if (foodPreparator2 != null)
        {
            if (twoTask)
            {
                timer.setMaxTime(60);
                foodPreparator2.reseted = false;
                foodPreparator2.reject = false;
            }
            else
            {
                timer.setMaxTime(40);
            }
        }
        reject = false;
        reseted = false;
        for (int i = 0; i < SIZE; i++) {
            objective[i] = ingredientTask[i];
        }
        for (int i = 0; i < maxLiquids; i++)
        {
            liquidObjective[i] = liquidTask[i];
        }
        if (servedPimkyu >= 2)
        {
            bool hasPimkyu = false;
            for (int k = 0; k < SIZE; k++)
            {
                if (objective[k] == 2)
                {
                    hasPimkyu = true;
                }
            }
            if (hasPimkyu)
            {
                reject = true;
            }
        }
        timer.resetTimer();
        timer.start();
    }
    public void SetObjectiveBasic(int[] ingredientTask, float[] liquidTask)
    {
        objective = new int[SIZE];
        liquidObjective = new float[maxLiquids];
        for (int i = 0; i < SIZE; i++)
        {
            objective[i] = ingredientTask[i];
        }
        for (int i = 0; i < maxLiquids; i++)
        {
            liquidObjective[i] = liquidTask[i];
        }
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
    public void resetFoodGame()
    {
        bool lleno = false;
        for (int i = 0; i < top; i++)
        {
            if(preparing[i] != 0)
            {
                if (!reseted)
                {
                    lleno = true;
                }
            }
            preparing[i] = 0;
        }
        if (lleno)
        {
            reseted = true;
        }
        top = 0;
        resetLiquidGame();
        if (twoTask)
        {
            foodPreparator2.resetFoodGame();
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
        for (int i = 0; i < sliderFills.Length; i++)
        {
            sliderFills[i].transform.position = sliderPointInit.transform.position;
            quantities[i] = 0;
            RectTransform rs = sliderFills[i].GetComponent<RectTransform>();
            rs.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
        }
    }
    public void resetLiquidGame()
    {
        bool lleno = false;
        quantityP = 0;
        for (int i = 0; i < maxLiquids; i++)
        {
            if (liquids[i] != 0)
            {
                if (!reseted)
                {
                    lleno = true;
                }
            }
            liquids[i] = 0;
        }
        if (lleno)
        {
            reseted = true;
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
            if(!((liquids[i] < (liquidObjective[i] + 5)) && (liquids[i] > (liquidObjective[i] - 5))))
            {
                return false;
            }
        }
        return true;
    }
    
    public void liquidChangeAlfaUp()
    {
        t1 += Time.deltaTime / 0.5f;
        float startAlfa = 0;
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
