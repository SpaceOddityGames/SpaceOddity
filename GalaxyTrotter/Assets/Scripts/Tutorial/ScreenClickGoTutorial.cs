using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenClickGoTutorial : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.SetActive(false);
        this.gameObject.GetComponentInParent<DialogController>().disableClient();
        this.gameObject.GetComponentInParent<DialogController>().goTutorial();
    }
}
