using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    private Queue<string> dialogQueue = new Queue<string>();
    private int count = 0;
    private int[] conditions;
    private Texts text;
    private bool textForMain = false;
    private bool skipText = false;

    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI DialogText;
    [SerializeField] GameObject dialogText;
    [SerializeField] GameObject dialogBox;
    [SerializeField] TextMeshProUGUI DialogTextForMain;
    [SerializeField] GameObject dialogTextForMain;
    [SerializeField] GameObject dialogBoxForMain;
    [SerializeField] GameObject clickScreen;
    [SerializeField] GameObject clickScreenKitchen;
    [SerializeField] GameObject clickScreenRemoveCharacter;
    [SerializeField] GameObject clickScreenSkipText;

    [SerializeField] FoodPreparation foodPreparation;
    [SerializeField] GameObject kitchen;

    GameObject client;

    public void ActivateDialogBox(Texts textObj, GameObject c, int[] cond)
    {
        text = textObj;
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        client = c;
        ActivateText(text.initTexts, cond);
    }

    public void ActivateText(string[] texts, int[] cond)
    {
        count = 0;
        conditions = cond;
        dialogQueue.Clear();
        foreach (string saveText in texts)
        {
            dialogQueue.Enqueue(saveText);
        }
        nextString();
    }
    public void nextString()
    {
        clickScreen.SetActive(false);
        if (dialogQueue.Count == 0)
        {
            dialogBox.SetActive(false);
            dialogText.SetActive(false);
            return;
        }
        if (textForMain)
        {
            dialogBox.SetActive(false);
            dialogText.SetActive(false);
            dialogBoxForMain.SetActive(true);
            dialogTextForMain.SetActive(true);
            DialogTextForMain.text = "";
        }
        else
        {
            dialogBox.SetActive(true);
            dialogText.SetActive(true);
            dialogBoxForMain.SetActive(false);
            dialogTextForMain.SetActive(false);
            DialogText.text = "";
        }
        string actualString = dialogQueue.Dequeue();
        StartCoroutine(PrintCharacters(actualString, conditions[count]));
        count++;
    }
    IEnumerator PrintCharacters(string actualString, int condition)
    {
        skipText = false;
        DialogText.text += "";
        DialogTextForMain.text += "";
        clickScreenSkipText.SetActive(true);
        foreach (char character in actualString.ToCharArray())
        {
            if (!skipText)
            {
                yield return new WaitForSeconds(0.04f);
                if (!textForMain)
                {
                    DialogText.text += character;
                }
                else
                {
                    DialogTextForMain.text += character;
                }
            }
            else
            {

            }
        }
        if (skipText)
        {
            if (!textForMain)
            {
                DialogText.text = actualString;
            }
            else
            {
                DialogTextForMain.text = actualString;
            }
        }
        clickScreenSkipText.SetActive(false);
        switch (condition)
        {
            case 0:
                textForMain = false;
                clickScreen.SetActive(true);
                break;
            case 1:
                clickScreenKitchen.SetActive(true);
                break;
            case 2:
                clickScreenRemoveCharacter.SetActive(true);
                break;
            case 3:
                textForMain = true;
                clickScreen.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void setSkipText(bool value)
    {
        skipText = value;
    }
    public void goKitchenTask()
    {
        foodPreparation.SetObjective(text.recipe.ingredientRecipe, text.recipe.liquidRecipe);
        dialogBox.SetActive(false);
        dialogText.SetActive(false);
        client.SetActive(false);
        kitchen.SetActive(true);
        this.GetComponent<ChangeRoom>().goKitchen();
    }
    public void goKitchen()
    {
        this.GetComponent<ChangeRoom>().goKitchen();
    }
    public void goMain()
    {
        kitchen.SetActive(false);
        this.GetComponent<ChangeRoom>().goMain();
    }
    public void correctResult()
    {
        client.SetActive(true);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        ActivateText(text.correctResult, text.correctResultConditions);
        gameManager.evaluateCorrectReputation(text.aceptTask);
    }
    public void wrongResult()
    {
        client.SetActive(true);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        ActivateText(text.wrongResult, text.wrongResultConditions);
        gameManager.reduceReputation();
    }
    public void wrongResultTimer()
    {
        client.SetActive(true);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        ActivateText(text.wrongResultTimer, text.wrongResultTimerConditions);
        gameManager.reduceReputation();
    }

    public void cancelResult()
    {
        client.SetActive(true);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        ActivateText(text.cancelResult, text.cancelResultConditions);
        gameManager.evaluateRejectReputation(text.aceptTask);
    }
    public void disableClient()
    {
        client.SetActive(false);
    }
    public void removeClient()
    {
        Destroy(client);
        dialogBox.SetActive(false);
        dialogText.SetActive(false);
    }
    public void nextClient()
    {
        StartCoroutine(waitForClient());
    }
    IEnumerator waitForClient()
    {
        yield return new WaitForSeconds(1);
        gameManager.nextClient();
    }
}
