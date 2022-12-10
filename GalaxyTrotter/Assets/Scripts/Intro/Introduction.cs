using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Introduction : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Fade fadeNegro;
    [SerializeField] GameObject tableta;
    [SerializeField] public TextMeshProUGUI introText;
    [SerializeField] GameObject clickScreenBlack;
    [SerializeField] GameObject pausa;
    [SerializeField] GameObject skip;
    bool skipText = false;

    public void Start()
    {
        StartCoroutine(activateTableta());
    }
    public void deactivateBlack()
    {
        fadeNegro.activate();
        StartCoroutine(waitFade());
    }
    IEnumerator waitFade()
    {
        yield return new WaitForSeconds(1f);
        pausa.SetActive(true);
    }

    public void skipIntro()
    {
        skipText = true;
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
    }
    IEnumerator activateTableta()
    {
        pausa.SetActive(false);
        fadeNegro.activate();
        yield return new WaitForSeconds(1f);
        tableta.gameObject.SetActive(true);
        skip.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(printCharactersBlack("¡Enhorabuena! Ha sido seleccionado para el puesto de \ncamarero del bar The Booze Way. Acuda mañana a la \nestación espacial de Naber para incorporarse, le recibirá \nel jefe encargado del bar y le dará más indicaciones.\n\n\n-Atte: Gestión de empleados de la estación espacial de Naber."));
    }
    /*
    IEnumerator printCharactersBlack(string actualString)
    {
        FindObjectOfType<AudioManager>().Play("texto");
        foreach (char character in actualString.ToCharArray())
        {
            if (!skipText)
            {
                yield return new WaitForSeconds(0.04f);
                introText.text += character;
            }
        }
        if (skipText)
        {
            introText.text = actualString;
        }
        FindObjectOfType<AudioManager>().Stop("texto");
        clickScreenBlack.SetActive(true);
    }*/
    IEnumerator printCharactersBlack(string actualString)
    {
        FindObjectOfType<AudioManager>().Play("texto");
        int index = 0;
        float t = 0;
        while (index < actualString.Length)
        {
            t += Time.deltaTime / 0.04f;
            index = Mathf.FloorToInt(t);
            index = Mathf.Clamp(index, 0, actualString.Length);
            introText.text = actualString.Substring(0, index);
            if (skipText)
            {
                introText.text = actualString;
                index = actualString.Length;
            }
            yield return null;
        }
        FindObjectOfType<AudioManager>().Stop("texto");
        clickScreenBlack.SetActive(true);
    }
}