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
        p.GetComponent<TextMeshProUGUI>().text = "   -     Bebida entregada con ingredientes incorrectos";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorLiq() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     Bebida entregada con liquidos incorrectos";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorNorma() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     Bebida entregada incumpliendo las normas";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryCorrect() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     Bebida entregada correctamente";
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void addHistoryCorrectReseted() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     Bebida correcta pero se han desperdiciado ingredientes";
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void addHistoryCorrectReject() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     Cliente rechazado correctamente";
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void addHistoryErrorAlergia() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     Bebida entregada a cliente con alergias";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorTime() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     Tiempo de espera demasiado largo";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorIngAndLiq() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     Bebida entregada con ingredientes y liquidos incorrectos";
        p.transform.localScale = new Vector3(1, 1, 1);
        alerta.SetActive(true);
    }
    public void addHistoryErrorReject() //
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = "   -     El cliente no ha recibido la bebida";
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
