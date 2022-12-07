using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMovement : MonoBehaviour
{
    //private bool yas = false;
    public int type;
    Canvas canvas;
    public float velocidad = 150;
    private bool b = true;
    private float time;
    public float timeToSwap=0.4f;
    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    void Update()
    {
        time += Time.deltaTime / timeToSwap;
        switch (type)
        {
            case 0:
                if (b)
                {
                    transform.position += Vector3.left * velocidad * Time.deltaTime * canvas.scaleFactor;
                }
                else
                {
                    transform.position += Vector3.right * velocidad * Time.deltaTime * canvas.scaleFactor;
                }
                break;
            case 1:
                if (b)
                {
                    transform.position += Vector3.right * velocidad * Time.deltaTime * canvas.scaleFactor;
                }
                else
                {
                    transform.position += Vector3.left * velocidad * Time.deltaTime * canvas.scaleFactor;
                }
                break;
            case 2:
                if (b)
                {
                    transform.position += Vector3.up * velocidad * Time.deltaTime * canvas.scaleFactor;
                }
                else
                {
                    transform.position += Vector3.down * velocidad * Time.deltaTime * canvas.scaleFactor;
                }
                break;
            case 3:
                if (b)
                {
                    transform.position += Vector3.down * velocidad * Time.deltaTime * canvas.scaleFactor;
                }
                else
                {
                    transform.position += Vector3.up * velocidad * Time.deltaTime * canvas.scaleFactor;
                }
                break;
        }
        if (time > 1)
        {
            b = !b;
            time = 0;
        }
    }
}
