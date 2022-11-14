using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickPoli2 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameManager gameManager;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsPoli();
        int[] cond = new int[2];
        cond[0] = 0;
        cond[1] = 2;
        string[] text = new string[2];
        text[0] = "Está bien, si acabas recordando algún detalle no dudes en comunicárnoslo.";
        text[1] = "Que tenga un buen día.";
        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
        gameManager.h07 = false;
    }
}

