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
    [SerializeField] TabletButtonBar tabletButtonBar;
    [SerializeField] TabletManager tablet;
    private void Start()
    {
        tabletButtonBar.inactive = true;
        tablet.deactivateTablet();
    }
    public void ActivateBegin()
    {
        activateBeginText();
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
        int index = 0;
        float t = 0;
        while (index < actualString.Length)
        {
            t += Time.deltaTime / 0.05f;
            index = Mathf.FloorToInt(t);
            index = Mathf.Clamp(index, 0, actualString.Length);
            beginText.text = actualString.Substring(0, index);
            yield return null;
        }
        /*
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            beginText.text += character;
        }*/
        clickScreenBegin.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("texto");
    }

    public void deactivateBegin()
    {
        tabletButtonBar.inactive = false;
        beginText.text = "";
        pausa.SetActive(true);
        beginImage.fadeOut();
        gameManager.nextClient();
        this.gameObject.SetActive(false);
    }
}
