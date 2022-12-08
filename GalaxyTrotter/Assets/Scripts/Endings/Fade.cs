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

    public void deactivate()
    {
        this.gameObject.SetActive(false);
    }
    public void activate()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        deactivate();
    }
}
