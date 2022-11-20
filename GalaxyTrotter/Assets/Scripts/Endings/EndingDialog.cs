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
                StartCoroutine(printCharactersBlack("Jornada " + (gameManager.day) + " completada con �xito"));
            }
            else
            {
                StartCoroutine(printCharactersBlack("Jornada " + (gameManager.day + 1) + " fallida"));
            }
        }
    }
    public void activateEndText()
    {
        if (gameManager.h02)
        {
            StartCoroutine(printCharactersEnd("Final: Bar Libre\n\nSe han encontrado pruebas en contra de la USI.\nGracias al chip introducido, se ha conseguido informaci�n que demuestra el asesinato de tu jefe y otras irregularidades. La estaci�n espacial de Naber ha sido expropiada de los altos cargos, expulsando todo rastro de la Uni�n de Sistemas Interplanetarios, ahora pertenece al gobierno de Azius. T� sigues trabajando como camarero en el The Booze Way."));
        }
        else if (gameManager.h03)
        {
            StartCoroutine(printCharactersEnd("Final: Bar USI\n\nNaber se ha convertido en un punto de conexi�n con la USI.\nEl �xito de la reformada estaci�n espacial ha impulsado la influencia de la Uni�n de Sistemas Interplanetarios en la zona. T� sigues trabajando como camarero en el The Booze Way bajo las �rdenes de la USI."));
        }
        else if (gameManager.h04)
        {
            StartCoroutine(printCharactersEnd("Final: Despedido\n\nHas sido despedido.\nTu jefe ha decidido echarte del The Booze Way, no has cumplido con los requisitos que se exigen."));
        }
        else if (gameManager.h05)
        {
            StartCoroutine(printCharactersEnd("Final: Ejecutado\n\nLa USI te ha capturado.\nHas sido trasladado a la Uni�n de Sistemas Interplanetarios donde se te ha juzgado por tus cr�menes y se te ha sentenciado a MUERTE."));
        }
        else
        {
            StartCoroutine(printCharactersEnd("Jornada " + (gameManager.day + 1) + "\n\nReputaci�n actual: " + gameManager.reputation + " / " + gameManager.maxReputation));
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
        foreach (char character in actualString.ToCharArray())
        {
            FindObjectOfType<AudioManager>().Play("unidadTextoGrave");
            yield return new WaitForSeconds(0.1f);
            blackText.text += character;
        }
        clickScreenBlack.SetActive(true);
    }
    IEnumerator printCharactersEnd(string actualString)
    {
        deactivateEndText();
        FindObjectOfType<AudioManager>().Play("texto");
        foreach (char character in actualString.ToCharArray())
        {
            yield return new WaitForSeconds(0.05f);
            endText.text += character;
        }
        clickScreenEnd.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("texto");
    }
}
