using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletManager : MonoBehaviour
{
    [SerializeField] TutorialManager tutorial;
    [SerializeField] GameObject pantallaBase;
    [SerializeField] GameObject pantallaInicio;
    [SerializeField] GameObject pantallaRazas;
    [SerializeField] GameObject pantallaMapa;
    [SerializeField] GameObject pantallaNotas;
    [SerializeField] GameObject pantallaRecetas;
    [SerializeField] GameObject[] infoRecetas;
    [SerializeField] GameObject[] infoRazas;
    [SerializeField] GameObject[] infoMapas;
    [SerializeField] TabletButton tabletButton;
    [HideInInspector] public bool tuto1 = false;
    [HideInInspector] public bool tuto2 = false;
    [HideInInspector] public bool tuto3 = false;
    [HideInInspector] public bool tuto4 = false;
    private int aux = 0;
    private int aux2 = 0;
    private int aux3 = 0;

    public void activatePantallaRazas()
    {
        if (tuto1)
        {
            return;
        }
        pantallaRazas.SetActive(true);
    }
    public void activatePantallaMapa()
    {
        if (tuto1)
        {
            return;
        }
        pantallaMapa.SetActive(true);
    }
    public void activatePantallaNotas()
    {
        if (tuto1)
        {
            return;
        }
        pantallaNotas.SetActive(true);
    }
    public void activatePantallaRecetas()
    {
        if (tuto1)
        {
            tutorial.nextText();
        }
        pantallaRecetas.SetActive(true);
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
        infoRecetas[aux].SetActive(false);
        infoRazas[aux2].SetActive(false);
        pantallaRazas.SetActive(false);
        pantallaMapa.SetActive(false);
        pantallaNotas.SetActive(false);
        pantallaRecetas.SetActive(false);
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
            this.gameObject.SetActive(false);
            tabletButton.gameObject.SetActive(true);
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
            this.gameObject.SetActive(false);
            tabletButton.gameObject.SetActive(true);
            return;
        }
        infoRecetas[aux].SetActive(false);
        infoRazas[aux2].SetActive(false);
        infoMapas[aux3].SetActive(false);
        pantallaRazas.SetActive(false);
        pantallaMapa.SetActive(false);
        pantallaNotas.SetActive(false);
        pantallaRecetas.SetActive(false);
        this.gameObject.SetActive(false);
        tabletButton.gameObject.SetActive(true);
        tabletButton.enableIngredients();
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
        infoRecetas[aux].SetActive(false);
        infoRecetas[num].SetActive(true);
        aux = num;
    }
    public void activateRaza(int num)
    {
        infoRazas[aux2].SetActive(false);
        infoRazas[num].SetActive(true);
        aux2 = num;
    }
    public void activateMapa(int num)
    {
        infoMapas[aux3].SetActive(false);
        infoMapas[num].SetActive(true);
        aux3 = num;
    }
}

