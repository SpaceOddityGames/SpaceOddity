using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endings : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Fade blackImage;
    [SerializeField] Fade endImage;
    EndingDialog endDialog;
    private void Start()
    {
        endDialog = this.gameObject.GetComponent<EndingDialog>();
    }
    public void endDay(bool correct)
    {
        StartCoroutine(activateBlack(correct));
    }
    public void deactivateBlack()
    {
        endImage.gameObject.SetActive(true);
        blackImage.fadeOut();
        StartCoroutine(activateEnd());
    }
    IEnumerator activateBlack(bool correct)
    {
        blackImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        endDialog.activateBlackText(correct);
    }
    IEnumerator activateEnd()
    {
        yield return new WaitForSeconds(1);
        endDialog.activateEndText();
    }

    public void deactivateEnd()
    {
        endImage.gameObject.SetActive(false);
    }
}
