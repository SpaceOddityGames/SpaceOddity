using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientUnit : MonoBehaviour
{
    public GameObject mainIngredient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Caldero")
        {
            mainIngredient.GetComponent<Ingredient>().drop = true;
            mainIngredient.GetComponent<Ingredient>().caldero = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Caldero")
        {
            mainIngredient.GetComponent<Ingredient>().drop = true;
        }
    }
    //**
}
