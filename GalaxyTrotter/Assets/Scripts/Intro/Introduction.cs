using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Introduction : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Fade blackImage;
    [SerializeField] GameObject tableta;
    [SerializeField] GameObject boton;
    [SerializeField] GameObject tabletUI;
    [SerializeField] GameObject perfil;
    [SerializeField] GameObject localizacion;
    [SerializeField] GameObject especie;
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
        blackImage.fadeOut();
        tableta.GetComponent<Fade>().fadeOut();
        boton.GetComponent<Fade>().fadeOut();
        tabletUI.GetComponent<Fade>().fadeOut();
        perfil.GetComponent<Fade>().fadeOut();
        localizacion.GetComponent<Fade>().fadeOut();
        especie.GetComponent<Fade>().fadeOut();
        skip.GetComponent<Fade>().fadeOut();
        pausa.SetActive(true);
    }

    public void skipIntro()
    {
        skipText = true;
    }
    IEnumerator activateTableta()
    {
        pausa.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        tableta.gameObject.SetActive(true);
        boton.gameObject.SetActive(true);
        tabletUI.gameObject.SetActive(true);
        perfil.gameObject.SetActive(true);
        localizacion.gameObject.SetActive(true);
        especie.gameObject.SetActive(true);
        skip.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(printCharactersBlack("�Enhorabuena! Ha sido seleccionado para el puesto de \ncamarero del bar The Booze Way. Acuda ma�ana a la \nestaci�n espacial de Naber para incorporarse, le recibir� \nel jefe encargado del bar y le dar� m�s indicaciones.\n\n\n-Atte: Gesti�n de empleados de la estaci�n espacial de Naber."));
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