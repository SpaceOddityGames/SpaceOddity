using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOp2_2 : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsOp2();
        FindObjectOfType<AudioManager>().Play("botonMenu");
        int[] cond = new int[6];
        cond[0] = 0;
        cond[1] = 0;
        cond[2] = 0;
        cond[3] = 20;
        cond[4] = 0;
        cond[5] = 2;
        string[] text = new string[16];
        text[0] = "Hay una nueva regulación. Por culpa de la guerra el suministro de pimkiyu desde Plokan ha caído, así que a partir de hoy su consumo está limitado. ";
        text[1] = "En tu caso, solo podrás servirlo 2 veces por día a los 2 primeros clientes que pidan una bebida que lo contenga.";
        text[2] = "Si te piden más bebidas que lleven pimkiyu tendrás que cancelar la comanda.";
        text[3] = "¿Te ha quedado claro?";
        text[4] = "Perfecto, pues nada más. Te dejo empezar a trabajar.";
        text[5] = "¡Buena suerte!";

        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
    }
}
