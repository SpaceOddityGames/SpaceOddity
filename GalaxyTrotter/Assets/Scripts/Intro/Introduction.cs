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
        pausa.SetActive(true);
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
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(printCharactersBlack("¡Enhorabuena! Ha sido seleccionado para el puesto de camarero del bar The Booze Way. Acuda mañana a la estación espacial de Naber para incorporarse, le recibirá \nel jefe encargado del bar y le dará más indicaciones.\n\n\n-Atte: Gestión de empleados de la estación espacial de Naber."));
    }

    IEnumerator printCharactersBlack(string actualString)
    {
        FindObjectOfType<AudioManager>().Play("texto");
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            introText.text += character;
        }
        FindObjectOfType<AudioManager>().Stop("texto");
        clickScreenBlack.SetActive(true);
    }
}