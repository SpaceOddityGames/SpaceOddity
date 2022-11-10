using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Texts 
{
    [TextArea(2, 6)]
    public string[] initTexts;
    public int[] initConditions; // 0 = no conditions / 1 = go Kitchen to work / 2 = remove character / 3 = main character / 4 = start Tutorial / 5 = opciones contrabandista C.1.6 / 6 = Lerman C.2.6 holograma / 7 = Lerman C.2.6 opciones / 8 = h01 toFalse C.1.6
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
    public bool twoTasks; // true = dos bebidas // false = 1 bebida
    public Recipe recipe2;
}
