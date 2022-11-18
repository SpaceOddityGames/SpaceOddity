using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMovement : MonoBehaviour
{
    //private bool yas = false;
    public int type;
    public float velocidad =200;
    private bool b = true;
    private float time;
    public float timeToSwap=0.4f;
    void Update()
    {
        time += Time.deltaTime / timeToSwap;
        if (time>1) 
        {
            b = !b;
            time = 0;
        }
        switch (type)
        {
            case 0:
                if (b)
                {
                    transform.position += Vector3.left * velocidad * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.right * velocidad * Time.deltaTime;
                }
                break;
            case 1:
                if (b)
                {
                    transform.position += Vector3.right * velocidad * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.left * velocidad * Time.deltaTime;
                }
                break;
            case 2:
                if (b)
                {
                    transform.position += Vector3.up * velocidad * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.down * velocidad * Time.deltaTime;
                }
                break;
            case 3:
                if (b)
                {
                    transform.position += Vector3.down * velocidad * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.up * velocidad * Time.deltaTime;
                }
                break;
        }
        
    }
}
