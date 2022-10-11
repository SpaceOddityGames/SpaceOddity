using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidIngredient : MonoBehaviour
{
    public int foodType;

    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 initPos;
    void Start()
    {
        initPos = gameObject.transform.position;
    }
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    void OnMouseDrag()
    {
        this.transform.position = GetMouseWorldPos() + mOffset;
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
            caldero.GetComponent<FoodPreparation>().addIngredient(foodType);
        }
        this.transform.position = initPos;
    }
}
