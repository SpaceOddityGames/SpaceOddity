using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlechasFeedback : MonoBehaviour
{
    private float t1 = 0;
    private float t2 = 0;
    
    void Start()
    {
        t1 = 0;
        t2 = 0;
    }
    private void Update()
    {
        t1 += Time.deltaTime / 0.9f;
        if (t1 > 1)
        {
            t2 += Time.deltaTime / 0.5f;
            float newAlfa = Mathf.Lerp(1, 0, t2);
            Color newColor = this.GetComponent<Image>().color;
            newColor.a = newAlfa;
            this.GetComponent<Image>().color = newColor;
            if (t2 > 1)
            {
                resetAlfa();
            }
        }
    }
    private void resetAlfa()
    {
        Color newColor = this.GetComponent<Image>().color;
        newColor.a = 1;
        this.GetComponent<Image>().color = newColor;
        t1 = 0;
        t2 = 0;
        this.gameObject.SetActive(false);
    }
}
