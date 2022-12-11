using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Historial : MonoBehaviour
{
    [SerializeField] GameObject textArea;
    [SerializeField] GameObject newObj;
    [SerializeField] GameObject alerta;
    public void addHistory()
    {
        GameObject p = Instantiate(newObj, new Vector3(0,0,0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void addHistoryErrorIng() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tBebida entregada con ingredientes incorrectos";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorLiq() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tBebida entregada con liquidos incorrectos";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorNorma() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tBebida entregada incumpliendo las normas";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryCorrect() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tBebida entregada correctamente";
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void addHistoryCorrectReseted() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tBebida correcta pero se han desperdiciado ingredientes";
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void addHistoryCorrectReject() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tCliente rechazado correctamente";
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void addHistoryCorrectRejectReseted() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tRechazo correcto pero se han gastado ingredientes";
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void addHistoryErrorAlergia() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tBebida entregada a cliente con alergias";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorTime() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tTiempo de espera demasiado largo";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorIngAndLiq() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tBebida entregada con ingredientes y liquidos incorrectos";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorReject() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -\tEl cliente no ha recibido la bebida";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void eliminateHistory()
    {
        alerta.SetActive(false);
        for (int i = textArea.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(textArea.transform.GetChild(i).gameObject);
        }
    }
}
