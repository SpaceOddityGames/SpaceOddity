using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] Button buttonPlay;
    [SerializeField] Button buttonContact;
    [SerializeField] GameObject imagenCarga;

    public void Start()
    {
        buttonPlay.onClick.AddListener(() => StartGame());
        buttonContact.onClick.AddListener(() => OpenContact());
    }
    private void StartGame()
    {
        //SceneManager.LoadScene(1);
        imagenCarga.SetActive(true);
        StartCoroutine(carga());
    }
    private void OpenContact()
    {

    }
    private IEnumerator carga()
    {
        AsyncOperation operacionCarga = SceneManager.LoadSceneAsync(1);
        while (!operacionCarga.isDone)
        {
            yield return null;
        }
        
    }

}
