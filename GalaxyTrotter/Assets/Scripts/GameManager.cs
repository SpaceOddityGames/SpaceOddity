using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour
{
    public int reputation;
    [SerializeField] public int maxReputation = 20;
    [SerializeField] private const int reputationAument = 1;
    [SerializeField] private const int reputationReduction = 3;
    [SerializeField] private const int minimumReputation = 5;
    public int day;
    [SerializeField] private ArrayLayout clients;
    [HideInInspector] public int clientNum;
    [SerializeField] Endings endManager;
    [SerializeField] KitchenController kitchenController;
    [SerializeField] FoodPreparation foodPreparator;
    [SerializeField] Slider reputationSlider;
    [SerializeField] GameObject flechaVerde;
    [SerializeField] GameObject flechaRoja;
    [SerializeField] Introduction introManager;
    [SerializeField] BeginingDialog begining;
    [SerializeField] GameObject pause;

    // Evolución de la partida
    public bool h01 = false;
    public bool h02 = false;
    public bool h03 = false;
    public bool h04 = false;
    public bool h05 = false;
    public bool h06 = false;
    public bool h07 = false;
    public bool h08 = false;
    public bool h09 = false; //Lerman
    public bool h10 = false;

    void Start()
    {
        
        if (FindObjectOfType<PasarInfo>().continuar)
        {
            loadGame();
        }
        else
        {
            newGame();
        }
        startDay();
        kitchenController.updateKitchenElements(day);
        reputationSlider.maxValue = maxReputation;
        updateSliderBar();
    }
    public void nextClient()
    {
        FindObjectOfType<AudioManager>().Stop("liquido");
        FindObjectOfType<AudioManager>().Stop("liquido2");
        if (day == 6 && clientNum == 0)
        {
            if (!h01 && h10)
            {
                h05 = true;
                clientNum = 2;
                StartCoroutine(waitForClient());
                return;
            }
            if (!h06 && h08)
            {
                h04 = true;
                clientNum = 0;
                StartCoroutine(waitForClient());
                return;
            }
            if (h07)
            {
                h04 = true;
                clientNum = 1;
                StartCoroutine(waitForClient());
                return;
            }
            clientNum = 3;
            StartCoroutine(waitForClient());
            return;
        }
        StartCoroutine(waitForClient());
    }
    public void invokeClient()
    {
        if (clientNum < clients.Day[day].Client.Length)
        {
            GameObject p = Instantiate(clients.Day[day].Client[clientNum], new Vector3(-609.1f, 30f, -244.2f), Quaternion.Euler(90, 180, 0));
            clientNum++;
        }
        else
        {
            endDay();
        }
    }
    public void startDay()
    {
        if (Convert.ToBoolean(PlayerPrefs.GetInt("existGame")))
        {
            reputation = PlayerPrefs.GetInt("reputation");
        }
        FindObjectOfType<AudioManager>().Play("gameTheme");
        if (day == 0)
        {
            reputation = 10;
            FindObjectOfType<AudioManager>().Stop("gameTheme");
            begining.gameObject.SetActive(false);
            introManager.gameObject.SetActive(true);
            kitchenController.updateKitchenElements(day);
            return;
        }
        begining.gameObject.SetActive(true);
        begining.ActivateBegin();
        pause.SetActive(false);
        kitchenController.updateKitchenElements(day);
    }
    public void endDay()
    {
        FindObjectOfType<AudioManager>().Stop("gameTheme");
        clientNum = 0;
        if (evaluateReputation())
        {
            day++;
            if (reputation > maxReputation)
            {
                reputation = maxReputation;
            }
            endManager.endDay(true);
            if(!h02 && !h03 && !h04 && !h05)
            {
                if (!h01 && h10)
                {
                    return;
                }
                if (!h06 && h08)
                {
                    return;
                }
                if (h07)
                {
                    return;
                }
                saveGame();
            }
        }
        else
        {
            if (reputation < 0)
            {
                reputation = 0;
            }
            endManager.endDay(false);
        }
    }
    public void setReputation(int value)
    {
        reputation = value;
    }
    public void evaluateCorrectReputation(bool value, bool tipo, bool reseted)
    {
        if (value)
        {
            if (foodPreparator.reject || foodPreparator.foodPreparator2.reject)
            {
                FindObjectOfType<Historial>().addHistoryErrorNorma();
                reduceReputation();
                return;
            }
            if (!reseted)
            {
                FindObjectOfType<Historial>().addHistoryCorrect();
                aumentReputation();
            }
            else
            {
                if (foodPreparator.tutorial)
                {
                    foodPreparator.tutorial = false;
                    return;
                }
                FindObjectOfType<Historial>().addHistoryCorrectReseted();
            }
        }
        else
        {
            reduceReputation();
            if (tipo)
            {
                FindObjectOfType<Historial>().addHistoryErrorNorma();
            }
            else
            {
                FindObjectOfType<Historial>().addHistoryErrorAlergia();
            }
        }
    }
    public void evaluateRejectReputation(bool value, bool tipo)
    {
        if (!value)
        {
            FindObjectOfType<Historial>().addHistoryCorrectReject();
            aumentReputation();
        }
        else
        {
            reduceReputation();
            FindObjectOfType<Historial>().addHistoryErrorReject();
        }
    }
    public void aumentReputation()
    {
        reputation += reputationAument;
        FindObjectOfType<AudioManager>().Play("reputacionUp");
        flechaVerde.SetActive(true);
        if (reputation >20)
        {
            reputation = 20;
        }
        updateSliderBar();
    }
    public void reduceReputation()
    {
        reputation -= reputationReduction;
        FindObjectOfType<AudioManager>().Play("reputacionDown");
        flechaRoja.SetActive(true);
        if (reputation < 0)
        {
            reputation = 0;
        }
        updateSliderBar();
    }
    public bool evaluateReputation()
    {
        if (reputation >= minimumReputation)
        {
            return true;
        }
        else
        {
            return false; //end game
        }
    }
    public void updateSliderBar()
    {
        reputationSlider.value = reputation;
    }
    IEnumerator waitForClient()
    {
        yield return new WaitForSeconds(1);
        invokeClient();
    }
    public void newGame()
    {
        h01 = false;
        h02 = false;
        h03 = false;
        h04 = false;
        h05 = false;
        h06 = false;
        h07 = false;
        h08 = false;
        h09 = false;
        h10 = false;

        day = 0;
    }
    public void saveGame()
    {
        PlayerPrefs.SetInt("existGame", Convert.ToInt32(true));

        PlayerPrefs.SetInt("h01", Convert.ToInt32(h01));
        PlayerPrefs.SetInt("h02", Convert.ToInt32(h02));
        PlayerPrefs.SetInt("h03", Convert.ToInt32(h03));
        PlayerPrefs.SetInt("h04", Convert.ToInt32(h04));
        PlayerPrefs.SetInt("h05", Convert.ToInt32(h05));
        PlayerPrefs.SetInt("h06", Convert.ToInt32(h06));
        PlayerPrefs.SetInt("h07", Convert.ToInt32(h07));
        PlayerPrefs.SetInt("h08", Convert.ToInt32(h08));
        PlayerPrefs.SetInt("h09", Convert.ToInt32(h09));
        PlayerPrefs.SetInt("h10", Convert.ToInt32(h10));

        PlayerPrefs.SetInt("day", day);
        PlayerPrefs.SetInt("reputation", reputation);

        PlayerPrefs.Save();
    }
    public void loadGame()
    {
        h01 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h02 = Convert.ToBoolean(PlayerPrefs.GetInt("h02"));
        h03 = Convert.ToBoolean(PlayerPrefs.GetInt("h03"));
        h04 = Convert.ToBoolean(PlayerPrefs.GetInt("h04"));
        h05 = Convert.ToBoolean(PlayerPrefs.GetInt("h05"));
        h06 = Convert.ToBoolean(PlayerPrefs.GetInt("h06"));
        h07 = Convert.ToBoolean(PlayerPrefs.GetInt("h07"));
        h08 = Convert.ToBoolean(PlayerPrefs.GetInt("h08"));
        h09 = Convert.ToBoolean(PlayerPrefs.GetInt("h09"));
        h10 = Convert.ToBoolean(PlayerPrefs.GetInt("h10"));

        day = PlayerPrefs.GetInt("day");
        reputation = PlayerPrefs.GetInt("reputation");

    }
}
