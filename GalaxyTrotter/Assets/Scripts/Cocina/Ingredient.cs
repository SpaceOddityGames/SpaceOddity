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

    //
    private Vector3 screenPosition;
    private Vector3 worldPosition;

    private Plane plane = new Plane(new Vector3(0, 0, 1), -11.3f);
    private void OnMouseDown()
    {
        if (isEnabled)
        {
            /*
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();*/
            screenPosition = Input.mousePosition;
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
        /*
        if (isEnabled)
        {
            seleccion.transform.position = GetMouseWorldPos() + mOffset;

        }*/
        if (isEnabled)
        {
            //this.transform.position = GetMouseWorldPos() + mOffset;
            screenPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            if (plane.Raycast(ray, out float distance))
            {
                worldPosition = ray.GetPoint(distance);
            }
            seleccion.transform.position = worldPosition;
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
            seleccion.GetComponent<IngredientUnit>().dropping = true;
            seleccion.GetComponent<IngredientUnit>().startPos = seleccion.transform.position;
            seleccion.GetComponent<IngredientUnit>().targetPos = caldero.transform.position;
        }
        else
        {
            Destroy(seleccion);
        }
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
