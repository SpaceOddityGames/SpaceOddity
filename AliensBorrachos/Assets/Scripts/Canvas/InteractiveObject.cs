using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractiveObject : MonoBehaviour, IPointerDownHandler
{
    public Texts textos;
    private void OnMouseDown()
    {
        //FindObjectOfType<DialogController>().ActivateDialogBox(textos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //FindObjectOfType<DialogController>().ActivateDialogBox(textos);
    }
}
