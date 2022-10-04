using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Texts textos;
    private void OnMouseDown()
    {
        FindObjectOfType<DialogController>().ActivateDialogBox(textos);
    }
}
