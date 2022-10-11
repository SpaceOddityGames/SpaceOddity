using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Texts 
{
    [TextArea(2, 6)]
    public string[] initTexts;
    public int[] initConditions; // 0 = no conditions / 1 = cooking condition / 2 = other
    public string[] correctResult;
    public int[] correctResultConditions; // 0 = no conditions / 2 = remove character
    public string[] wrongResult;
    public int[] wrongResultConditions; // 0 = no conditions / 2 = remove character
    public int[] recipe = new int[5];
    
}
