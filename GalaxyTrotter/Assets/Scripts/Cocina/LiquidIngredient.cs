using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidIngredient : MonoBehaviour
{
    public int LiquidType;

    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 initPos;
    private bool isEnabled = true;
    void Start()
    {
        initPos = gameObject.transform.position;
    }
    private void OnMouseDown()
    {
        if (isEnabled)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }
    }
    void OnMouseDrag()
    {
        if (isEnabled)
        {
            this.transform.position = GetMouseWorldPos() + mOffset;
        }
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    ////////////////////////////
    public bool drop = false;
    public GameObject caldero;
    private void OnMouseUp()
    {
        if (drop)
        {
            drop = false;
        }
        this.transform.position = initPos;
        if(caldero != null)
        {
            caldero.GetComponent<FoodPreparation>().alfaDown = true;
        }
        caldero = null;
    }
    private void dropLiquid()
    {
        caldero.GetComponent<FoodPreparation>().dropLiquid(LiquidType);
    }
    private void Update()
    {
        if (drop)
        {
            caldero.GetComponent<FoodPreparation>().alfaUp = true;
            dropLiquid();
        } else if(caldero != null)
        {
            caldero.GetComponent<FoodPreparation>().alfaDown = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Caldero")
        {
            caldero = other.gameObject;
            drop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Caldero")
        {
           drop = false;
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
