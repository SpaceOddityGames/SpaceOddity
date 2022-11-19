using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCB2 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameManager gameManager;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsCB();
        FindObjectOfType<AudioManager>().Play("botonMenu");
        /*
        int[] cond = new int[4];
        cond[0] = 0;
        cond[1] = 3;
        cond[2] = 0;
        cond[3] = 2;
        string[] text = new string[4];
        text[0] = "��No me vas a invitar!? �En serio?";
        text[1] = "Lo siento, est� prohibido servir bebidas gratuitas.";
        text[2] = "�Vaya ratas!";
        text[3] = "En fin, pues ma�ana vuelvo entonces. Aunque no puedo quedarme muchos m�s d�as por aqu�.";
        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);*/
        this.gameObject.GetComponentInParent<DialogController>().cancelResult();
    }
}
