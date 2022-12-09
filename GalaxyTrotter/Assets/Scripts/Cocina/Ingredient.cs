using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int foodType;
    public GameObject ingredient;
    private GameObject seleccion;
    private bool isEnabled = true;
    private bool isPaused = false;

    //**
    //Función para arrastrar objetos
    private Vector3 mOffset;
    private float mZCoord;

    //
    private Vector3 screenPosition;
    private Vector3 worldPosition;

    private Plane plane = new Plane(new Vector3(0, 0, 1), -11.3f);

    private float floor;

    [SerializeField] GameObject childIngredient;

    private void Start()
    {
        switch (foodType)
        {
            case 1:
                floor = -5;
                break;
            case 2:
                floor = -5;
                break;
            case 3:
                floor = -5;
                break;
            case 4:
                floor = -6;
                break;
            case 5:
                floor = -5;
                break;
            case 6:
                floor = -5;
                break;
            case 7:
                floor = -5;
                break;
            case 8:
                floor = -5;
                break;
            case 9:
                this.GetComponent<BoxCollider>().enabled = true;
                childIngredient.SetActive(true);
                floor = -5;
                break;
            case 10:
                this.GetComponent<BoxCollider>().enabled = true;
                childIngredient.SetActive(true);
                floor = -6;
                break;
            default:
                floor = -7;
                break;
        }
    }
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
            if(foodType >= 9)
            {
                childIngredient.SetActive(false);
            }
            switch (foodType)
            {
                case 1:
                    //FindObjectOfType<AudioManager>().Play("hongustar");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("hongustar");
                    break;
                case 2:
                    //FindObjectOfType<AudioManager>().Play("pimkiyu");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("pimkiyu");
                    break;
                case 3:
                    //FindObjectOfType<AudioManager>().Play("odzia");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("odzia");
                    break;
                case 4:
                    //FindObjectOfType<AudioManager>().Play("scorw");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("scorw");
                    break;
                case 5:
                    //FindObjectOfType<AudioManager>().Play("molpo");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("molpo");
                    break;
                case 6:
                    //FindObjectOfType<AudioManager>().Play("do");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("do");
                    break;
                case 7:
                    //FindObjectOfType<AudioManager>().Play("dees");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("dees");
                    break;
                case 8:
                    //FindObjectOfType<AudioManager>().Play("cristal");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("cristal");
                    break;
                case 9:
                    //FindObjectOfType<AudioManager>().Play("moonso");
                    FindObjectOfType<AudioManager>().PlayRandomPitch("moonso");
                    break;
            }
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
        if (isEnabled && !isPaused)
        {
            //this.transform.position = GetMouseWorldPos() + mOffset;
            screenPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            if (plane.Raycast(ray, out float distance))
            {
                worldPosition = ray.GetPoint(distance);
            }
            if (worldPosition.y < floor)
            {
                worldPosition.y = floor;
            }
            if(seleccion != null)
            {
                seleccion.transform.position = worldPosition;
            }
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
            if (foodType >= 9)
            {
                this.GetComponent<BoxCollider>().enabled = false;
            }
            caldero.GetComponent<FoodPreparation>().addIngredient(foodType);
            //FindObjectOfType<AudioManager>().Play("echarIngrediente");
            FindObjectOfType<AudioManager>().PlayRandomPitch("echarIngrediente");
            seleccion.GetComponent<IngredientUnit>().dropping = true;
            seleccion.GetComponent<IngredientUnit>().startPos = seleccion.transform.position;
            seleccion.GetComponent<IngredientUnit>().targetPos = caldero.transform.position;
        }
        else
        {
            Destroy(seleccion);
            if (foodType >= 9)
            {
                childIngredient.SetActive(true);
            }
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
    public void pause()
    {
        isPaused = true;
    }
    public void resume()
    {
        isPaused = false;
    }
}
