using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArrayLayout 
{
    [System.Serializable]
    public struct rowData
    {
        public GameObject[] Client;
    }

    public rowData[] Day = new rowData[2];
}
