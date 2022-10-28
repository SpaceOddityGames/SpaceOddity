using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareButton : MonoBehaviour
{
    public GameObject bowl;

    private void OnMouseDown()
    {
        bowl.GetComponent<FoodPreparation>().preparationResult();
    }
}
