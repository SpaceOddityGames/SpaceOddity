using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientUnit : MonoBehaviour
{
    public GameObject mainIngredient;


    // reduccion de size
    public Vector3 targetScale;
    public bool dropping = false;
    private float t = 0;
    private Vector3 startScale;
    public Vector3 startPos;
    public Vector3 targetPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Caldero" || other.gameObject.tag == "Caldero2")
        {
            mainIngredient.GetComponent<Ingredient>().drop = true;
            mainIngredient.GetComponent<Ingredient>().caldero = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Caldero" || other.gameObject.tag == "Caldero2")
        {
            mainIngredient.GetComponent<Ingredient>().drop = false;
        }
    }
    //**
    private void Start()
    {
        startScale = this.transform.localScale;
    }
    private void Update()
    {
        if (dropping)
        {
            targetScale = new Vector3(0, 0, 0);
            t += Time.deltaTime / 0.6f;
            Vector3 newScale = Vector3.Lerp(startScale, targetScale, t);
            Vector3 newPos = Vector3.Lerp(startPos, targetPos, t);
            this.transform.localScale = newScale;
            this.transform.position = newPos;
            if (t > 1)
            {
                dropping = false;
                Destroy(this.gameObject);
            }
        }
    }
}
