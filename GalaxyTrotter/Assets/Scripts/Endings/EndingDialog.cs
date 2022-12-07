using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingDialog : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI blackText;
    [SerializeField] public TextMeshProUGUI endText;
    [SerializeField] GameObject clickScreenBlack;
    [SerializeField] GameObject clickScreenEnd;
    public void activateBlackText(bool completed)
    {
        if(gameManager.h02 || gameManager.h03 || gameManager.h04 || gameManager.h05)
        {
            StartCoroutine(printCharactersBlack("FIN DEL JUEGO"));
        }
        else
        {
            if (completed)
            {
                StartCoroutine(printCharactersBlack("JORNADA " + (gameManager.day) + " COMPLETADA CON ÉXITO"));
            }
            else
            {
                StartCoroutine(printCharactersBlack("JORNADA " + (gameManager.day + 1) + " FALLIDA\nREPUTACIÓN FINAL " + gameManager.reputation + "/20"));
            }
        }
    }
    public void activateEndText()
    {
        if (gameManager.h02)
        {
            StartCoroutine(printCharactersEnd("Final: Bar Libre\n\nSe han encontrado pruebas en contra de la USI.\nGracias al chip introducido, se ha conseguido información que demuestra el asesinato de tu jefe y otras irregularidades. La estación espacial de Naber ha sido expropiada de los altos cargos, expulsando todo rastro de la Unión de Sistemas Interplanetarios, ahora pertenece al gobierno de Azius. Tú sigues trabajando como camarero en el The Booze Way."));
        }
        else if (gameManager.h03)
        {
            StartCoroutine(printCharactersEnd("Final: Bar USI\n\nNaber se ha convertido en un punto de conexión con la USI.\nEl éxito de la reformada estación espacial ha impulsado la influencia de la Unión de Sistemas Interplanetarios en la zona. Tú sigues trabajando como camarero en el The Booze Way bajo las órdenes de la USI."));
        }
        else if (gameManager.h04)
        {
            StartCoroutine(printCharactersEnd("Final: Despedido\n\nHas sido despedido.\nTu jefe ha decidido echarte del The Booze Way, no has cumplido con los requisitos que se exigen."));
        }
        else if (gameManager.h05)
        {
            StartCoroutine(printCharactersEnd("Final: Ejecutado\n\nLa USI te ha capturado.\nHas sido trasladado a la Unión de Sistemas Interplanetarios donde se te ha juzgado por tus crímenes y se te ha sentenciado a MUERTE."));
        }
    }
    public void deactivateBlackText()
    {
        blackText.text = "";
    }
    public void deactivateEndText()
    {
        endText.text = "";
    }
    IEnumerator printCharactersBlack(string actualString)
    {
        deactivateBlackText();
        int index = 0;
        float t = 0;
        while (index < actualString.Length)
        {
            FindObjectOfType<AudioManager>().Play("unidadTextoGrave");
            t += Time.deltaTime / 0.1f;
            index = Mathf.FloorToInt(t);
            index = Mathf.Clamp(index, 0, actualString.Length);
            blackText.text = actualString.Substring(0, index);
            yield return null;
        }
        /*
        foreach (char character in actualString.ToCharArray())
        {
            FindObjectOfType<AudioManager>().Play("unidadTextoGrave");
            yield return new WaitForSeconds(0.1f);
            blackText.text += character;
        }*/
        clickScreenBlack.SetActive(true);
    }
    IEnumerator printCharactersEnd(string actualString)
    {
        deactivateEndText();
        FindObjectOfType<AudioManager>().Play("texto");
        int index = 0;
        float t = 0;
        while (index < actualString.Length)
        {
            t += Time.deltaTime / 0.05f;
            index = Mathf.FloorToInt(t);
            index = Mathf.Clamp(index, 0, actualString.Length);
            endText.text = actualString.Substring(0, index);
            yield return null;
        }
        /*
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            endText.text += character;
        }*/
        clickScreenEnd.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("texto");
    }
}
