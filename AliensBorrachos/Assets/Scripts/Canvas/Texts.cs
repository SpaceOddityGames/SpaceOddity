using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Texts 
{
    [TextArea(2, 6)]
    public string[] arrayTexts;
    public int[] conditions; // 0 = no conditions / 1 = cooking condition / 2 = other
    public int[] recipe = new int[5];
    
}
