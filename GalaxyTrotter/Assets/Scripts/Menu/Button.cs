using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject Boton;
    [SerializeField] GameObject BotonHover;
    public void OnHover()
    {
        Boton.SetActive(false);
        BotonHover.SetActive(true);
    }

    public void ExitHover()
    {
        Boton.SetActive(true);
        BotonHover.SetActive(false);
    }
}
