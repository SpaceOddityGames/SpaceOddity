using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenClickIntro : MonoBehaviour, IPointerClickHandler
{
    private bool comprobate;
    private void Start()
    {
        comprobate = false;
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!comprobate)
        {
            comprobate = true;
            this.gameObject.GetComponentInParent<Introduction>().deactivateBlack();
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        FindObjectOfType<AudioManager>().Play("gameTheme");
        yield return new WaitForSeconds(1.0f);
        this.gameObject.GetComponentInParent<Introduction>().introText.text = "";
        FindObjectOfType<GameManager>().nextClient();
        comprobate = false;
        this.gameObject.GetComponentInParent<Introduction>().gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
