using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletButtonBar : MonoBehaviour
{
    [SerializeField] GameObject tablet;
    [SerializeField] GameObject botonApagado;

    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool inactive = false;
    public void OnMouseDown()
    {
        if (!paused && !inactive)
        {
            FindObjectOfType<AudioManager>().Play("abrirTablet");
            tablet.SetActive(true);
            botonApagado.GetComponent<Button>().interactable = true;
            this.gameObject.SetActive(false);
        }

    }
}
