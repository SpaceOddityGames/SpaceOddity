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
    [SerializeField] public TextMeshProUGUI introText;
    [SerializeField] GameObject clickScreenBlack;

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
    }
    IEnumerator activateTableta()
    {
        yield return new WaitForSeconds(0.5f);
        tableta.gameObject.SetActive(true);
        boton.gameObject.SetActive(true);
        tabletUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(printCharactersBlack("�Enhorabuena! Ha sido seleccionado para el puesto de camarero del bar The Booze Way. Acuda ma�ana a la estaci�n espacial de Naber para incorporarse, le recibir� \nel jefe encargado del bar y le dar� m�s indicaciones.\n\n\n-Atte: Gesti�n de empleados de la estaci�n espacial de Naber."));
    }

    IEnumerator printCharactersBlack(string actualString)
    {
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            introText.text += character;
        }
        clickScreenBlack.SetActive(true);
    }
}