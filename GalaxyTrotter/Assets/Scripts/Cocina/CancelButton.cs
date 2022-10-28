using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour
{
    public GameObject bowl;
    private void OnMouseDown()
    {
        bowl.GetComponent<FoodPreparation>().cancelTask();
    }
}
