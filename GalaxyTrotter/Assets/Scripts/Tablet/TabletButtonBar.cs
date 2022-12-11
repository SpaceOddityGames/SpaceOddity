using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletButtonBar : MonoBehaviour
{
    [SerializeField] GameObject tablet;
    [SerializeField] GameObject botonApagado;
    [SerializeField] GameObject botonHistorial;
    [SerializeField] GameObject botonRazas;
    [SerializeField] GameObject botonMapa;
    [SerializeField] GameObject botonNotas;
    [SerializeField] GameObject botonIngredientes;

    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool inactive = false;
    public void OnMouseDown()
    {
        if (!paused && !inactive)
        {
            FindObjectOfType<AudioManager>().Play("abrirTablet");
            tablet.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(waitButtons());
        }

    }
    IEnumerator waitButtons()
    {
        yield return new WaitForSeconds(0.7f);
        botonApagado.GetComponent<Button>().interactable = true;
        botonHistorial.GetComponent<Button>().interactable = true;
        botonRazas.GetComponent<Button>().interactable = true;
        botonMapa.GetComponent<Button>().interactable = true;
        botonNotas.GetComponent<Button>().interactable = true;
        botonIngredientes.GetComponent<Button>().interactable = true;
        
        botonHistorial.GetComponent<HoverButtons>().enabled = true;
        botonRazas.GetComponent<HoverButtons>().enabled = true;
        botonMapa.GetComponent<HoverButtons>().enabled = true;
        botonNotas.GetComponent<HoverButtons>().enabled = true;
        botonIngredientes.GetComponent<HoverButtons>().enabled = true;
        
        this.gameObject.SetActive(false);
    }
}
