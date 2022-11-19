using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject kitchenCamera;
    public void goKitchen()
    {
        mainCamera.SetActive(false);
        kitchenCamera.SetActive(true);
    }
    public void goMain()
    {
        mainCamera.SetActive(true);
        kitchenCamera.SetActive(false);
    }
}
