using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int foodType;
    public GameObject ingredient;
    private GameObject seleccion;

    //**
    //Función para arrastrar objetos
    private Vector3 mOffset;
    private float mZCoord;
    
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        seleccion = Instantiate(ingredient, gameObject.transform.position, Quaternion.identity);
        seleccion.GetComponent<IngredientUnit>().mainIngredient = this.gameObject;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        seleccion.transform.position = GetMouseWorldPos() + mOffset;
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
            StartCoroutine(cocinar());
            drop = false;
            caldero.GetComponent<FoodPreparation>().addIngredient(foodType);
        }
        Destroy(seleccion);
    }
    
    //Ejemplo de corrutina
    private IEnumerator cocinar()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("ingrediente cocinando");
    }
    //**
}
