using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingDialog : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI blackText;
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] GameObject clickScreenBlack;
    [SerializeField] GameObject clickScreenEnd;
    public void activateBlackText(bool completed)
    {
        if (completed)
        {
            StartCoroutine(printCharactersBlack("Jornada " + (gameManager.day)+ " completada con éxito"));
        }
        else
        {
            StartCoroutine(printCharactersBlack("Jornada " + (gameManager.day+1) + " fallida"));
        }
        
    }
    public void activateEndText()
    {
        StartCoroutine(printCharactersEnd("Jornada " + (gameManager.day+1) +"\n\nReputación actual: " + gameManager.reputation+" / " + gameManager.maxReputation));
    }
    public void deactivateBlackText()
    {
        blackText.text = "";
    }
    public void deactivateEndText()
    {
        endText.text = "";
    }
    IEnumerator printCharactersBlack(string actualString)
    {
        deactivateBlackText();
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.1f);
            blackText.text += character;
        }
        clickScreenBlack.SetActive(true);
    }
    IEnumerator printCharactersEnd(string actualString)
    {
        deactivateEndText();
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            endText.text += character;
        }
        clickScreenEnd.SetActive(true);
    }
}
