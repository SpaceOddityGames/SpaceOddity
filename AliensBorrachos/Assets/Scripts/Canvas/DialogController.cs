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
    private int[] conditions;
    Texts text;
    [SerializeField] TextMeshProUGUI DialogText;
    [SerializeField] GameObject dialogText;
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject clickScreen;
    [SerializeField] GameObject clickScreenKitchen;
    [SerializeField] GameObject clickScreenRemoveCharacter;


    [SerializeField] FoodPreparation foodPreparation;


    GameObject client;

    public void ActivateDialogBox(Texts textObj, GameObject c, int[] cond)
    {
        //anim.SetTrigger("OpenDialogBox");
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
        string actualString = dialogQueue.Dequeue();
        DialogText.text = "";
        StartCoroutine(PrintCharacters(actualString, conditions[count]));
        count++;
    }

    IEnumerator PrintCharacters(string actualString, int condition)
    {
        DialogText.text += "";
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.03f);
            DialogText.text += character;
        }
        switch (condition)
        {
            case 0:
                break;
            case 1:
                clickScreenKitchen.SetActive(true);
                clickScreen.SetActive(true);
                break;
            case 2:
                clickScreenRemoveCharacter.SetActive(true);
                break;
            default:
                break;
        }
        clickScreen.SetActive(true);
    }
    public void goKitchen()
    {
        foodPreparation.SetObjective(text.recipe);
        dialogBox.SetActive(false);
        dialogText.SetActive(false);
        client.SetActive(false);
        this.GetComponent<ChangeRoom>().goKitchen();
    }
    public void goMain()
    {
        this.GetComponent<ChangeRoom>().goMain();
    }
    public void correctResult()
    {
        client.SetActive(true);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        ActivateText(text.correctResult, text.correctResultConditions);
    }
    public void wrongResult()
    {
        client.SetActive(true);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        ActivateText(text.wrongResult, text.wrongResultConditions);
    }
    public void nextClient()
    {

    }
}
