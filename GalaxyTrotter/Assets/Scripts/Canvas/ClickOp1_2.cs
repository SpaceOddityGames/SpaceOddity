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
        text[0] = "Te decía que hoy justo hemos decidido añadir una nueva bebida a nuestra carta, veremos si a la clientela le gusta.";
        text[1] = "También es probable que en los próximos días se añadan más, estamos expandiendo el negocio, así que estate atento a las recetas de la tablet.";
        text[2] = "Además a partir de hoy, habiéndo superado tu primer día, podrás rechazar pedidos a los clientes, tendrás que hacerlo en caso de que te pidan algo que no puedes servir o incumpla alguna regla.";
        text[3] = "Por cierto, una última cosilla.";
        text[4] = "Hoy tengo un asunto importante que atender, tengo que…";
        text[5] = "Bueno los detalles no importan, el tema es que estaré fuera todo el día.";
        text[6] = "Es posible que venga un tipo preguntando por mí, si es así, dile que no estoy, que venga mañana.";
        text[7] = "¿Vale?";
        text[8] = "Perfecto. Pues te dejo que empieces.";
        text[9] = "Bueno, por si acaso. Si el tipo se cabrea dile que le pagaré cinco mil más. Así seguro que no se queja.";
        text[10] = "Ahora sí, me voy, ¡buena suerte!";

        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
    }
}
