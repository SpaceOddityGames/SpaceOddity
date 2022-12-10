using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletButton : MonoBehaviour
{
    [SerializeField] GameObject tablet;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] LiquidIngredient[] liquids;
    [SerializeField] TutorialManager tutorial;
    [SerializeField] PostitButton postit;
    [SerializeField] GameObject botonApagado;
    [SerializeField] GameObject botonHistorial;
    [SerializeField] GameObject botonRazas;
    [SerializeField] GameObject botonMapa;
    [SerializeField] GameObject botonNotas;
    [SerializeField] GameObject botonIngredientes;
    [SerializeField] GameObject botonRecetas;
    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool inactive = false;
    [HideInInspector] public bool tutorialActive = false;
    private void Start()
    {
        tutorialActive = false;
    }
    public void OnMouseDown()
    {
        if (!paused && !inactive)
        {
            postit.inactive = true;
            FindObjectOfType<AudioManager>().Play("abrirTablet");
            tablet.SetActive(true);
            StartCoroutine(waitButtons());
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].disable();
            }
            for (int i = 0; i < liquids.Length; i++)
            {
                liquids[i].disable();
            }
            if (tutorialActive && !paused)
            {
                if (FindObjectOfType<TutorialManager>() != null)
                {
                    tutorial.nextText();
                }
                tutorialActive = false;
            }
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
        botonRecetas.GetComponent<Button>().interactable = true;
        botonHistorial.GetComponent<HoverButtons>().enabled = true;
        botonRazas.GetComponent<HoverButtons>().enabled = true;
        botonMapa.GetComponent<HoverButtons>().enabled = true;
        botonNotas.GetComponent<HoverButtons>().enabled = true;
        botonIngredientes.GetComponent<HoverButtons>().enabled = true;
        botonRecetas.GetComponent<HoverButtons>().enabled = true;
        this.gameObject.SetActive(false);
    }
    public void enableIngredients()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].enable();
        }
        for (int i = 0; i < liquids.Length; i++)
        {
            liquids[i].enable();
        }
    }
}

