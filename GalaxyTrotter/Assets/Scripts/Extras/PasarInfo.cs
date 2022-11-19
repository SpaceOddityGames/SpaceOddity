using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarInfo : MonoBehaviour
{
    public static PasarInfo instance;
    public bool continuar;
    void Awake()
    {
        continuar = false;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

        void Update()
    {
        
    }
}
