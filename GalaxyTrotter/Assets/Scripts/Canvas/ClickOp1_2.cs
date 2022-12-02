using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOp1_2 : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsOp1();
        FindObjectOfType<AudioManager>().Play("botonMenu");
        int[] cond = new int[11];
        cond[0] = 0;
        cond[1] = 0;
        cond[2] = 0;
        cond[3] = 0;
        cond[4] = 0;
        cond[5] = 0;
        cond[6] = 0;
        cond[7] = 19;
        cond[8] = 0;
        cond[8] = 0;
        cond[9] = 0;
        cond[10] = 2;
        string[] text = new string[11];
        text[0] = "Te dec�a que hoy justo hemos decidido a�adir una nueva bebida a nuestra carta, veremos si a la clientela le gusta.";
        text[1] = "Tambi�n es probable que en los pr�ximos d�as se a�adan m�s, estamos expandiendo el negocio, as� que estate atento a las recetas de la tablet.";
        text[2] = "Adem�s a partir de hoy, habi�ndo superado tu primer d�a, podr�s rechazar pedidos a los clientes, tendr�s que hacerlo en caso de que te pidan algo que no puedes servir o incumpla alguna regla.";
        text[3] = "Por cierto, una �ltima cosilla.";
        text[4] = "Hoy tengo un asunto importante que atender, tengo que�";
        text[5] = "Bueno los detalles no importan, el tema es que estar� fuera todo el d�a.";
        text[6] = "Es posible que venga un tipo preguntando por m�, si es as�, dile que no estoy, que venga ma�ana.";
        text[7] = "�Vale?";
        text[8] = "Perfecto. Pues te dejo que empieces.";
        text[9] = "Bueno, por si acaso. Si el tipo se cabrea dile que le pagar� cinco mil m�s. As� seguro que no se queja.";
        text[10] = "Ahora s�, me voy, �buena suerte!";

        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
    }
}
