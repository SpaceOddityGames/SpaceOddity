using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostitButton : MonoBehaviour
{
    [SerializeField] GameObject postit;
    [SerializeField] TabletButton tablet;
    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool inactive = false;

    public void OnMouseDown()
    {
        if (!paused && !inactive)
        {
            tablet.inactive = true;
            postit.SetActive(true);
            FindObjectOfType<AudioManager>().Play("papel");
            FindObjectOfType<KitchenController>().disableAll();
            this.gameObject.SetActive(false);
        }
    }
}
