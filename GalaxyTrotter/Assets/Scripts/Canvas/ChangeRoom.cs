using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject kitchenCamera;
    [SerializeField] GameObject botonRecetas;
    public void goKitchen()
    {
        botonRecetas.SetActive(true);
        mainCamera.SetActive(false);
        kitchenCamera.SetActive(true);
    }
    public void goMain()
    {
        botonRecetas.SetActive(false);
        mainCamera.SetActive(true);
        kitchenCamera.SetActive(false);
    }
}
