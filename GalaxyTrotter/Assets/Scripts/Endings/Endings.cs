using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endings : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Fade fadeNegro;
    [SerializeField] GameObject blackImage;
    [SerializeField] GameObject endImage;
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
        fadeNegro.activate();
        StartCoroutine(waitFade());
    }
    IEnumerator waitFade()
    {
        yield return new WaitForSeconds(1f);
        endDialog.deactivateBlackText();
        blackImage.SetActive(false);
        if (gameManager.h02 || gameManager.h03 || gameManager.h04 || gameManager.h05)
        {
            endImage.gameObject.SetActive(true);
            StartCoroutine(activateEnd());
            yield break;
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
        fadeNegro.activate();
        yield return new WaitForSeconds(1f);
        blackImage.gameObject.SetActive(true);
        pausa.SetActive(false);
        yield return new WaitForSeconds(1f);
        endDialog.activateBlackText(correct);

        FindObjectOfType<Historial>().eliminateHistory();
    }
    IEnumerator activateEnd()
    {
        yield return new WaitForSeconds(1);
        endDialog.activateEnd();
    }

    public void deactivateEnd()
    {
        fadeNegro.activate();
        StartCoroutine(waitFade2()); 
    }

    IEnumerator waitFade2()
    {
        yield return new WaitForSeconds(1f);
        pausa.SetActive(true);
        endImage.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
