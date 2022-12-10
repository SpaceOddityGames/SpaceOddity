using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeginingDialog : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    [SerializeField] Fade fadeNegro;
    [SerializeField] TextMeshProUGUI beginText;
    [SerializeField] GameObject clickScreenBegin;
    [SerializeField] GameObject pausa;
    [SerializeField] TabletButtonBar tabletButtonBar;
    [SerializeField] TabletManager tablet;
    [SerializeField] GameObject imageJornada1;
    [SerializeField] GameObject imageJornada2;
    [SerializeField] GameObject imageJornada3;
    private void Start()
    {
        tabletButtonBar.inactive = true;
        tablet.deactivateTablet();
    }
    public void ActivateBegin()
    {
        if(gameManager.day+1 == 1 || gameManager.day+1 == 2)
        {
            imageJornada1.SetActive(true);
            imageJornada2.SetActive(false);
            imageJornada3.SetActive(false);
        }
        else if (gameManager.day+1 == 3)
        {
            imageJornada2.SetActive(true);
            imageJornada1.SetActive(false);
            imageJornada3.SetActive(false);
        }
        else
        {
            imageJornada3.SetActive(true);
            imageJornada1.SetActive(false);
            imageJornada2.SetActive(false);
        }
        activateBeginText();
    }
    public void activateBeginText()
    {
        StartCoroutine(printCharactersBegin("COMIENZO DE LA JORNADA " + (gameManager.day + 1)));
    }

    public void deactivateBeginText()
    {
        beginText.text = "";
    }
    IEnumerator printCharactersBegin(string actualString)
    {
        yield return new WaitForSeconds(1f);
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
        fadeNegro.activate();
        StartCoroutine(waitFade());
        tabletButtonBar.inactive = false;
    }

    IEnumerator waitFade()
    {
        yield return new WaitForSeconds(1f);
        deactivateBeginText();
        pausa.SetActive(true);
        this.gameObject.SetActive(false);
        gameManager.nextClient();
    }
}
