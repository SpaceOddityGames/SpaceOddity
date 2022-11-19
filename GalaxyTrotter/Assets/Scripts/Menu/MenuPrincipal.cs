using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] GameObject ajustes;
    [SerializeField] GameObject creditos;
    [SerializeField] GameObject botonContinuar;
    [SerializeField] GameObject imagenCarga;
    public void Start()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("existGame")))
        {
            botonContinuar.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
            PlayerPrefs.SetFloat("music", 0.5f);
        }
        FindObjectOfType<AudioManager>().Stop("gameTheme");
        FindObjectOfType<AudioManager>().Play("menuTheme");
    }

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Stop("menuTheme");
        imagenCarga.SetActive(true);
        FindObjectOfType<PasarInfo>().continuar = false;
        StartCoroutine(carga());
    }

    public void ContinueGame()
    {
        FindObjectOfType<AudioManager>().Stop("menuTheme");
        imagenCarga.SetActive(true);
        FindObjectOfType<PasarInfo>().continuar = true;
        StartCoroutine(carga());
    }

    private IEnumerator carga()
    {
        AsyncOperation operacionCarga = SceneManager.LoadSceneAsync(1);
        operacionCarga.allowSceneActivation = false;
        yield return new WaitForSeconds(3.0f);
        operacionCarga.allowSceneActivation = true;
        while (!operacionCarga.isDone)
        {
            yield return null;
        }
    }

    public void OpenSettings()
    {
        ajustes.SetActive(true);
    }
    public void OpenCredits()
    {
        creditos.SetActive(true);
    }

    public void CloseCredits()
    {
        creditos.SetActive(false);
    }

    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().Stop("menuTheme");
        //Application.Quit();
        Application.ExternalEval("window.open('" + Application.absoluteURL + "','_self')");
    }

    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("botonMenu");
    }

}
