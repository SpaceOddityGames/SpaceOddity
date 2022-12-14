using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletManager : MonoBehaviour
{
    [SerializeField] TutorialManager tutorial;
    [SerializeField] GameObject pantallaBase;
    [SerializeField] GameObject pantallaInicio;
    [SerializeField] GameObject pantallaRazas;
    [SerializeField] GameObject pantallaMapa;
    [SerializeField] GameObject pantallaNotas;
    [SerializeField] GameObject pantallaIngredientes;
    [SerializeField] GameObject pantallaRecetas;
    [SerializeField] GameObject pantallaHistorial;
    [SerializeField] GameObject botonApagado;
    [SerializeField] GameObject botonHistorial;
    [SerializeField] GameObject botonRazas;
    [SerializeField] GameObject botonMapa;
    [SerializeField] GameObject botonNotas;
    [SerializeField] GameObject botonIngredientes;
    [SerializeField] GameObject botonRecetas;
    [SerializeField] PostitButton postit;
    [SerializeField] GameObject[] infoRecetas;
    [SerializeField] GameObject[] infoRazas;
    [SerializeField] GameObject[] infoMapas;
    [SerializeField] GameObject[] infoIngredientes;
    [SerializeField] GameObject[] alerta;
    [SerializeField] TabletButton tabletButton;
    [SerializeField] TabletButtonBar tabletButtonBar;
    [HideInInspector] public bool tuto1 = false;
    [HideInInspector] public bool tuto2 = false;
    [HideInInspector] public bool tuto3 = false;
    [HideInInspector] public bool tuto4 = false;
    private int aux = 0;
    private int aux2 = 0;
    private int aux3 = 0;
    private int aux4 = 0;
    [SerializeField] Animator anim;

    private void Start()
    {
        botonHistorial.GetComponent<HoverButtons>().enabled = false;
        botonRazas.GetComponent<HoverButtons>().enabled = false;
        botonMapa.GetComponent<HoverButtons>().enabled = false;
        botonNotas.GetComponent<HoverButtons>().enabled = false;
        botonIngredientes.GetComponent<HoverButtons>().enabled = false;
        botonRecetas.GetComponent<HoverButtons>().enabled = false;
    }
    public void activatePantallaRazas()
    {
        if (tuto1)
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        pantallaRazas.SetActive(true);
        alerta[4].SetActive(false);
    }
    public void activatePantallaMapa()
    {
        if (tuto1)
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        pantallaMapa.SetActive(true);
    }
    public void activatePantallaIngredientes()
    {
        if (tuto1)
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        pantallaIngredientes.SetActive(true);
        alerta[1].SetActive(false);
    }
    public void activatePantallaNotas()
    {
        if (tuto1)
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        pantallaNotas.SetActive(true);
        alerta[0].SetActive(false);
    }
    public void activatePantallaRecetas()
    {
        if (tuto1)
        {
            tutorial.nextText();
        }
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        pantallaRecetas.SetActive(true);
        alerta[2].SetActive(false);
    }
    public void activatePantallaHistorial()
    {
        if (tuto1)
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        pantallaHistorial.SetActive(true);
        alerta[3].SetActive(false);
    }
    public void activatePantallaInicio()
    {
        if (tuto1)
        {
            return;
        }
        if (tuto2)
        {
            tutorial.nextText();
            tuto2 = false;
        }
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        infoRecetas[aux].SetActive(false);
        infoRazas[aux2].SetActive(false);
        pantallaRazas.SetActive(false);
        pantallaMapa.SetActive(false);
        pantallaNotas.SetActive(false);
        pantallaRecetas.SetActive(false);
        pantallaIngredientes.SetActive(false);
        pantallaHistorial.SetActive(false);
    }
    public void deactivateTablet()
    {
        if (tuto1)
        {
            return;
        }
        if (tuto2)
        {
            return;
        }
        if (tuto3)
        {
            tuto3 = false;
            tutorial.nextText();
            infoRecetas[aux].SetActive(false);
            infoRazas[aux2].SetActive(false);
            infoMapas[aux3].SetActive(false);
            pantallaRazas.SetActive(false);
            pantallaMapa.SetActive(false);
            pantallaNotas.SetActive(false);
            pantallaRecetas.SetActive(false);
            pantallaHistorial.SetActive(false);
            this.gameObject.SetActive(false);
            tabletButton.gameObject.SetActive(true);
            tabletButtonBar.gameObject.SetActive(true);
            postit.inactive = true;
            return;
        }
        if (tuto4)
        {
            infoRecetas[aux].SetActive(false);
            infoRazas[aux2].SetActive(false);
            infoMapas[aux3].SetActive(false);
            pantallaRazas.SetActive(false);
            pantallaMapa.SetActive(false);
            pantallaNotas.SetActive(false);
            pantallaRecetas.SetActive(false);
            pantallaHistorial.SetActive(false);
            this.gameObject.SetActive(false);
            tabletButton.gameObject.SetActive(true);
            tabletButtonBar.gameObject.SetActive(true);
            postit.inactive = true;
            return;
        }
        infoRecetas[aux].SetActive(false);
        infoRazas[aux2].SetActive(false);
        infoMapas[aux3].SetActive(false);
        infoIngredientes[aux4].SetActive(false);
        pantallaRazas.SetActive(false);
        pantallaMapa.SetActive(false);
        pantallaNotas.SetActive(false);
        pantallaIngredientes.SetActive(false);
        pantallaRecetas.SetActive(false);
        pantallaHistorial.SetActive(false);
        this.gameObject.SetActive(false);
        tabletButton.gameObject.SetActive(true);
        tabletButtonBar.gameObject.SetActive(true);
        tabletButton.enableIngredients();
        postit.inactive = false;
    }

    public void botonApagar()
    {
        if (tuto1)
        {
            return;
        }
        if (tuto2)
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("cerrarTablet");
        anim.Play("tabletOut");
        botonApagado.GetComponent<Button>().interactable = false;
        botonHistorial.GetComponent<Button>().interactable = false;
        botonRazas.GetComponent<Button>().interactable = false;
        botonMapa.GetComponent<Button>().interactable = false;
        botonNotas.GetComponent<Button>().interactable = false;
        botonIngredientes.GetComponent<Button>().interactable = false;
        botonRecetas.GetComponent<Button>().interactable = false;
        botonHistorial.GetComponent<HoverButtons>().enabled = false;
        botonRazas.GetComponent<HoverButtons>().enabled = false;
        botonMapa.GetComponent<HoverButtons>().enabled = false;
        botonNotas.GetComponent<HoverButtons>().enabled = false;
        botonIngredientes.GetComponent<HoverButtons>().enabled = false;
        botonRecetas.GetComponent<HoverButtons>().enabled = false;
        tabletButton.GetComponent<BoxCollider>().enabled = true;
        tabletButtonBar.GetComponent<BoxCollider>().enabled = true;
    }

    /// Seccion Libro de recetas
    public void activateReceta(int num)
    {
        if (tuto1)
        {
            if (num != 0)
            {
                return;
            }
            tuto1 = false;
            tuto2 = true;
            tutorial.nextText();
        }
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        infoRecetas[aux].SetActive(false);
        infoRecetas[num].SetActive(true);
        aux = num;
    }
    public void activateRaza(int num)
    {
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        infoRazas[aux2].SetActive(false);
        infoRazas[num].SetActive(true);
        aux2 = num;
    }
    public void activateMapa(int num)
    {
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        infoMapas[aux3].SetActive(false);
        infoMapas[num].SetActive(true);
        aux3 = num;
    }
    public void activateIngrediente(int num)
    {
        FindObjectOfType<AudioManager>().Play("botonTabletIn");
        infoIngredientes[aux4].SetActive(false);
        infoIngredientes[num].SetActive(true);
        aux4 = num;
    }
}

