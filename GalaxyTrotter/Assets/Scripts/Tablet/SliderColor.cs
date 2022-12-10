using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColor : MonoBehaviour
{
    [SerializeField] Image relleno;
    [SerializeField] GameManager gameManager;
    public void updateColor()
    {
        if(gameManager.reputation < 5)
        {
            relleno.color = new Color32(240, 144, 126, 255);
        }
        else
        {
            relleno.color = new Color(231, 231, 231, 255);
        }
    }
}
