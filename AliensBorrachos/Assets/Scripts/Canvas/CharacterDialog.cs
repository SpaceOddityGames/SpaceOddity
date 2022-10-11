using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    public Texts textos;
    private void Start()
    {
        FindObjectOfType<DialogController>().ActivateDialogBox(textos, this.gameObject, textos.initConditions);
    }
}
