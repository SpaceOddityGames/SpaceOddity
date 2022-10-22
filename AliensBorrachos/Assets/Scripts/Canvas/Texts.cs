using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Texts 
{
    [TextArea(2, 6)]
    public string[] initTexts;
    public int[] initConditions; // 0 = no conditions / 1 = go Kitchen
    public string[] correctResult;
    public int[] correctResultConditions; // 0 = no conditions / 2 = remove character
    public string[] wrongResult;
    public int[] wrongResultConditions; // 0 = no conditions / 2 = remove character
    public string[] wrongResultTimer;
    public int[] wrongResultTimerConditions; // 0 = no conditions / 2 = remove character
    public string[] cancelResult;
    public int[] cancelResultConditions; // 0 = no conditions / 2 = remove character
    public Recipe recipe;
    public bool aceptTask; // true = has to acept / false = has to reject
}
