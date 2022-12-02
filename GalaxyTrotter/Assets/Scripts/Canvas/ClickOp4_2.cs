using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOp4_2 : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponentInParent<DialogController>().deactivateOptionsOp4();
        this.gameObject.GetComponentInParent<DialogController>().nextString();
        FindObjectOfType<AudioManager>().Play("botonMenu");
    }
}
