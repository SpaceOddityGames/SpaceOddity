using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickLerman1 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameManager gameManager;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsLerman();
        int[] cond = new int[2];
        cond[0] = 0;
        cond[1] = 2;
        string[] text = new string[2];
        text[0] = "�Perfecto! nuestra informaci�n es correcta entonces. Muchas gracias por su colaboraci�n, esto nos ayudar� a estrechar el cerco.";
        text[1] = "Y estate tranquilo, capturaremos a ese delincuente.";
        this.gameObject.GetComponentInParent<DialogController>().ActivateText(text, cond);
        gameManager.h01 = true;
    }
}
