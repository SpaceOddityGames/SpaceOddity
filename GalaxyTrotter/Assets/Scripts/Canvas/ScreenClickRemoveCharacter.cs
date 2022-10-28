using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenClickRemoveCharacter : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.SetActive(false);
        this.gameObject.GetComponentInParent<DialogController>().removeClient();
        this.gameObject.GetComponentInParent<DialogController>().nextClient();
    }
}

