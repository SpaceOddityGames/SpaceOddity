using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverOptions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Color c;
    Color aux;
    private void Start()
    {
        c = this.GetComponent<Image>().color;
        aux = new Color(0.85f, 0.85f, 0.85f, 1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(1.02f, 1.02f, 1.02f);
        this.GetComponent<Image>().color = aux;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(1f, 1f, 1f);
        this.GetComponent<Image>().color=c;
    }
}
