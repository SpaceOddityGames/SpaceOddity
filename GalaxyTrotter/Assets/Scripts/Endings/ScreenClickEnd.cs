using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScreenClickEnd : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
