using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    private Animator anim;
    private Queue<string> dialogQueue = new Queue<string>();
    Texts text;
    [SerializeField] TextMeshProUGUI DialogText;

    
    public void ActivateDialogBox(Texts textObj)
    {
        //anim.SetTrigger("OpenDialogBox");
        text = textObj;
        ActivateText();
    }

    public void ActivateText()
    {
        dialogQueue.Clear();
        foreach (string saveText in text.arrayTexts)
        {
            dialogQueue.Enqueue(saveText);
        }
        nextString();
    }
    public void nextString()
    {
        if (dialogQueue.Count == 0)
        {
            DeactivateDialogBox();
            return;
        }
        string actualString = dialogQueue.Dequeue();
        //DialogText.text = actualString;
        DialogText.text = "";
        StartCoroutine(PrintCharacters(actualString));
    }
    public void DeactivateDialogBox()
    {
       // anim.SetTrigger("CloseDialogBox");
    }

    IEnumerator PrintCharacters(string actualString)
    {
        DialogText.text += "";
        foreach (char character in actualString.ToCharArray())
        {
            DialogText.text += character;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
