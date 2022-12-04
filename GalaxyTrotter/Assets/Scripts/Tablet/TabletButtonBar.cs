using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletButtonBar : MonoBehaviour
{
    [SerializeField] GameObject tablet;

    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool inactive = false;
    public void OnMouseDown()
    {
        if (!paused && !inactive)
        {
            FindObjectOfType<AudioManager>().Play("abrirTablet");
            tablet.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }
}
