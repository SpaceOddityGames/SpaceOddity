using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GoToKitchen : MonoBehaviour
{
    [SerializeField] GameObject mainButton;
    [SerializeField] GameObject kitchenButton;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject kitchenCamera;
    private void Start()
    {
        kitchenButton.GetComponent<Button>().onClick.AddListener(onClick);
    }
    private void onClick()
    {
        mainButton.SetActive(true);
        kitchenButton.SetActive(false);

        mainCamera.SetActive(false);
        kitchenCamera.SetActive(true);
    }

    public void goKitchen()
    {
        mainButton.SetActive(true);
        kitchenButton.SetActive(false);

        mainCamera.SetActive(false);
        kitchenCamera.SetActive(true);
    }
}
