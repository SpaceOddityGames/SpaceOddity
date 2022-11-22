using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeginingDialog : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    [SerializeField] Fade beginImage;
    [SerializeField] TextMeshProUGUI beginText;
    [SerializeField] GameObject clickScreenBegin;
    [SerializeField] GameObject pausa;

    public void ActivateBegin()
    {
        activateBeginText();
        print("1");
    }
    public void activateBeginText()
    {
        StartCoroutine(printCharactersBegin("Jornada " + (gameManager.day + 1) + "\n\nReputación actual: " + gameManager.reputation + " / " + gameManager.maxReputation));
    }

    public void deactivateBeginText()
    {
        beginText.text = "";
    }
    IEnumerator printCharactersBegin(string actualString)
    {
        yield return new WaitForSeconds(0.3f);
        deactivateBeginText();
        FindObjectOfType<AudioManager>().Play("texto");
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            beginText.text += character;
        }
        clickScreenBegin.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("texto");
    }

    public void deactivateBegin()
    {
        beginText.text = "";
        pausa.SetActive(true);
        beginImage.fadeOut();
        gameManager.nextClient();
        this.gameObject.SetActive(false);
    }
}
