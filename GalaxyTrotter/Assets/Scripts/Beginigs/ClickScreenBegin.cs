using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickScreenBegin : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GetComponentInParent<BeginingDialog>().deactivateBegin();
        this.gameObject.SetActive(false);
    }
}
