using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickPoli1 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameManager gameManager;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        FindObjectOfType<AudioManager>().Play("botonMenu");
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsPoli();
        int[] cond = new int[3];
        cond[0] = 3;
        cond[1] = 0;
        cond[2] = 2;
        string[] text = new string[3];
        text[0] = "¿Cómo, que insinúa? ¿Tiene serias sospechas sobre ello?";
        text[1] = "Sí, agente.";
        text[2] = "Vale, le voy a pedir que venga conmigo un momento y me cuente lo que sepa.";
        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
        gameManager.h07 = true;
    }
}

