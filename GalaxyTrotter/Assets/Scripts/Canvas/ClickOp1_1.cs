using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOp1_1 : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsOp1();
        this.gameObject.GetComponentInParent<DialogController>().nextString();
        FindObjectOfType<AudioManager>().Play("botonMenu");
    }
}
