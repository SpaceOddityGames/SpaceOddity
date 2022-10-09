using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToMain : MonoBehaviour
{
    [SerializeField] GameObject mainButton;
    [SerializeField] GameObject kitchenButton;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject kitchenCamera;
    private void Start()
    {
        mainButton.GetComponent<Button>().onClick.AddListener(onClick);
    }
    private void onClick()
    {
        mainButton.SetActive(false);
        kitchenButton.SetActive(true);

        mainCamera.SetActive(true);
        kitchenCamera.SetActive(false);
    }
}
