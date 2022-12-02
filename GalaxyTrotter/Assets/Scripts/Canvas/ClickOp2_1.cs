using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOp2_1 : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsOp2();
        this.gameObject.GetComponentInParent<DialogController>().nextString();
        FindObjectOfType<AudioManager>().Play("botonMenu");
    }
}
