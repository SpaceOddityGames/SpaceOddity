using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CookingCondYes : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject DialogHandler;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        DialogHandler.GetComponent<DialogController>().aceptTask();
    }
}
