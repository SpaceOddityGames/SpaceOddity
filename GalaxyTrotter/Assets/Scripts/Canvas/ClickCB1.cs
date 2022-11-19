using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCB1 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameManager gameManager;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsCB();
        int[] cond = new int[1];
        cond[0] = 1;
        string[] text = new string[1];
        text[0] = "¡Así me gusta! Al final voy a salir contento del bar y todo.";
        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
        gameManager.h01 = true;
    }
}
