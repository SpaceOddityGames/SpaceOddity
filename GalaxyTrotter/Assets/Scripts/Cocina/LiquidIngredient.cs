using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiquidIngredient : MonoBehaviour
{
    public int LiquidType;

    private Vector3 mOffset;
    private float mZCoord;
    [HideInInspector] public Vector3 initPos;
    [HideInInspector] public Quaternion initRot;
    private bool isEnabled = true;
    //
    private Vector3 screenPosition;
    private Vector3 worldPosition;

    private Plane plane = new Plane(new Vector3(0,0,1), -11.3f);

    private float floor;
    void Start()
    {
        initPos = gameObject.transform.position;
        initRot = gameObject.transform.rotation;
        switch (LiquidType)
        {
            case 0:
                floor = -4.5f;
                break;
            case 1:
                floor = -2;
                break;
            case 2:
                floor = -4.5f;
                break;
        }
    }
    private void OnMouseDown()
    {
        if (isEnabled)
        {
            /*
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
            */
            screenPosition = Input.mousePosition;
        }
    }
    void OnMouseDrag()
    {
        if (isEnabled)
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
            transform.position = worldPosition;
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

            switch (LiquidType)
            {
                case 0:
                    transform.rotation = Quaternion.Euler(0, 0, -30);
                    break;
                case 1:
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    break;
                case 2:
                    transform.rotation = Quaternion.Euler(0, 0, 210);
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

    ////////////////////////////
    public bool drop = false;
    public GameObject caldero;
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        if (drop)
        {
            drop = false;
        }
        this.transform.position = initPos;
        this.transform.rotation = initRot;
        if (caldero != null)
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
            if(caldero.GetComponent<FoodPreparation>().quantityP < 100)
            {
                FindObjectOfType<AudioManager>().Play("liquido");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Caldero")
        {
            drop = false;
            FindObjectOfType<AudioManager>().Pause("liquido");
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
