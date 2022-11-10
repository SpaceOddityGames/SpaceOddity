using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickLerman2 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameManager gameManager;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsLerman();
        int[] cond = new int[2];
        cond[0] = 0;
        cond[1] = 2;
        string[] text = new string[2];
        text[0] = "Oh vaya, qué raro. Imagino que habremos recibido información falsa.";
        text[1] = "Pues si le ves por aquí por favor avisa a las autoridades.";
        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
        if(gameManager.h01 == false)
        {
            gameManager.h01 = false;
        }
    }
}
