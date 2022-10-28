using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int foodType;
    public GameObject ingredient;
    private GameObject seleccion;
    private bool isEnabled = true;

    //**
    //Función para arrastrar objetos
    private Vector3 mOffset;
    private float mZCoord;
    
    private void OnMouseDown()
    {
        if (isEnabled)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
            seleccion = Instantiate(ingredient, gameObject.transform.position, Quaternion.identity);
            seleccion.GetComponent<IngredientUnit>().mainIngredient = this.gameObject;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        if (isEnabled)
        {
            seleccion.transform.position = GetMouseWorldPos() + mOffset;
        }
    }
    //**

    //**
    //Comprobación si entra en el caldero
    public bool drop = false;
    public GameObject caldero;
    private void OnMouseUp()
    {
        if (drop)
        {
            drop = false;
            caldero.GetComponent<FoodPreparation>().addIngredient(foodType);
        }
        Destroy(seleccion);
    }
    public void enable()
    {
        isEnabled = true;
    }
    public void disable()
    {
        isEnabled = false;
    }
}
