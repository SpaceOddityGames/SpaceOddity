using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareButton : MonoBehaviour
{
    public GameObject bowl;

    private void OnMouseDown()
    {
        bool correct;
        correct= bowl.GetComponent<FoodPreparation>().prepareFood();
        Debug.Log("it is correct? " + correct);
    }
}
