using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] Button buttonPlay;
    [SerializeField] Button buttonContact;

    public void Start()
    {
        buttonPlay.onClick.AddListener(() => StartGame());
        buttonContact.onClick.AddListener(() => OpenContact());
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void OpenContact()
    {

    }

}
