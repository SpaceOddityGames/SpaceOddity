using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingDialog : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI blackText;
    [SerializeField] GameObject clickScreenBlack;
    [SerializeField] GameObject clickScreenEnd;
    [SerializeField] GameObject endingLibre;
    [SerializeField] GameObject endingUSI;
    [SerializeField] GameObject endingDespido;
    [SerializeField] GameObject endingEjecucion;
    public void activateBlackText(bool completed)
    {
        if(gameManager.h02 || gameManager.h03 || gameManager.h04 || gameManager.h05)
        {
            StartCoroutine(printCharactersBlack("FIN DEL JUEGO"));
        }
        else
        {
            if (completed)
            {
                StartCoroutine(printCharactersBlack("JORNADA " + (gameManager.day) + " COMPLETADA CON ÉXITO"));
            }
            else
            {
                StartCoroutine(printCharactersBlack("JORNADA " + (gameManager.day + 1) + " FALLIDA\nREPUTACIÓN FINAL: " + gameManager.reputation + "/20"));
            }
        }
    }
    public void activateEnd()
    {
        if (gameManager.h02)
        {
            endingLibre.SetActive(true);
        }
        else if (gameManager.h03)
        {
            endingUSI.SetActive(true);
        }
        else if (gameManager.h04)
        {
            endingDespido.SetActive(true);
        }
        else if (gameManager.h05)
        {
            endingEjecucion.SetActive(true);
        }
        clickScreenEnd.SetActive(true);
    }
    public void deactivateBlackText()
    {
        blackText.text = "";
    }
    IEnumerator printCharactersBlack(string actualString)
    {
        deactivateBlackText();
        int index = -1;
        float t = 0;
        while (index < actualString.Length)
        {
            t += Time.deltaTime / 0.1f;
            if(Mathf.FloorToInt(t) != index)
            {
                FindObjectOfType<AudioManager>().Play("unidadTextoGrave");
            }
            index = Mathf.FloorToInt(t);
            index = Mathf.Clamp(index, 0, actualString.Length);
            blackText.text = actualString.Substring(0, index);
            yield return null;
        }
        /*
        foreach (char character in actualString.ToCharArray())
        {
            FindObjectOfType<AudioManager>().Play("unidadTextoGrave");
            yield return new WaitForSeconds(0.1f);
            blackText.text += character;
        }*/
        clickScreenBlack.SetActive(true);
    }
}
