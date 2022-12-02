using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endings : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Fade blackImage;
    [SerializeField] Fade endImage;
    EndingDialog endDialog;
    [SerializeField] GameObject pausa;
    bool nextDay = false;
    private void Start()
    {
        endDialog = this.gameObject.GetComponent<EndingDialog>();
    }
    public void endDay(bool correct)
    {
        nextDay = correct;
        StartCoroutine(activateBlack(correct));
    }
    public void deactivateBlack()
    {
        blackImage.fadeOut();
        if (gameManager.h02 || gameManager.h03 || gameManager.h04 || gameManager.h05)
        {
            endImage.gameObject.SetActive(true);
            StartCoroutine(activateEnd());
            return;
        }
        if (nextDay)
        {
            gameManager.startDay();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator activateBlack(bool correct)
    {
        blackImage.gameObject.SetActive(true);
        pausa.SetActive(false);
        yield return new WaitForSeconds(2f);
        endDialog.activateBlackText(correct);

        FindObjectOfType<Historial>().eliminateHistory();
    }
    IEnumerator activateEnd()
    {
        yield return new WaitForSeconds(1);
        endDialog.activateEndText();
    }

    public void deactivateEnd()
    {
        endDialog.endText.text = "";
        pausa.SetActive(true);
        endImage.gameObject.SetActive(false);
    }
}
