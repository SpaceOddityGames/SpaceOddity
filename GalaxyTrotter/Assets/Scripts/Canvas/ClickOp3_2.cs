using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOp3_2 : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsOp3();
        FindObjectOfType<AudioManager>().Play("botonMenu");
        int[] cond = new int[6];
        cond[0] = 0;
        cond[1] = 2;
        string[] text = new string[16];
        text[0] = "¿Me ha tocado el empleado cortito? No pienso volver a explicártelo, apáñatelas.";
        text[1] = "Ponte a trabajar inmediatamente.";

        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
    }
}
