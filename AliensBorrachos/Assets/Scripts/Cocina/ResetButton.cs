using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject bowl;
    private void OnMouseDown()
    {
        bowl.GetComponent<FoodPreparation>().resetFood();
    }
}
