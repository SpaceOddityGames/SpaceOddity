using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }
    public void fadeIn()
    {
        anim.Play("FadeIn");
    }
    public void fadeOut()
    {
        anim.Play("FadeOut");
    }
    public void deactivate()
    {
        this.gameObject.SetActive(false);
    }
    public void activate()
    {
        this.gameObject.SetActive(true);
    }
}
