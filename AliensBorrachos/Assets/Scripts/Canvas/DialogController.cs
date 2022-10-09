using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DialogController : MonoBehaviour
{
    private Animator anim;
    private Queue<string> dialogQueue = new Queue<string>();
    private int count = 0; 
    Texts text;
    [SerializeField] TextMeshProUGUI DialogText;
    [SerializeField] GameObject dialogText;
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject clickScreen;

    [SerializeField] GameObject conditionalButtonY;
    [SerializeField] GameObject conditionalButtonN;

    [SerializeField] FoodPreparation foodPreparation;

    GameObject client;
    public void ActivateDialogBox(Texts textObj)
    {
        //anim.SetTrigger("OpenDialogBox");
        text = textObj;
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        ActivateText();
    }

    public void ActivateText()
    {
        count = 0;
        dialogQueue.Clear();
        foreach (string saveText in text.arrayTexts)
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
            DeactivateDialogBox();
            return;
        }
        string actualString = dialogQueue.Dequeue();
        //DialogText.text = actualString;
        DialogText.text = "";
        StartCoroutine(PrintCharacters(actualString, count));
        count++;
    }
    public void DeactivateDialogBox()
    {
       // anim.SetTrigger("CloseDialogBox");
    }

    IEnumerator PrintCharacters(string actualString, int count)
    {
        DialogText.text += "";
        foreach (char character in actualString.ToCharArray())
        {
            DialogText.text += character;
            yield return new WaitForSeconds(0.03f);
        }
        switch (text.conditions[count])
        {
            case 0:
                break;
            case 1:
                enablecookingConditional();
                break;
            default:
                break;
        }
        clickScreen.SetActive(true);
    }

    public void enablecookingConditional()
    {
        conditionalButtonN.SetActive(true);
        conditionalButtonY.SetActive(true);
        clickScreen.SetActive(false);
    }

    public void disableCookingConditional()
    {
        conditionalButtonN.SetActive(false);
        conditionalButtonY.SetActive(false);
        clickScreen.SetActive(false);
    }
    public void aceptTask()
    {
        foodPreparation.SetObjective(text.recipe);
        this.GetComponent<GoToKitchen>().goKitchen();
        disableCookingConditional();
    }
    public void rejectTask()
    {
        //////////////////////////////////
    }
}
