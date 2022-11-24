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
        StartCoroutine(waitForClient());
    }
    public void invokeClient()
    {
        if (clientNum < clients.Day[day].Client.Length)
        {
            GameObject p = Instantiate(clients.Day[day].Client[clientNum], new Vector3(-609.1f, 27f, -244.2f), Quaternion.Euler(90, 180, 0));
            clientNum++;
        }
        else
        {
            endDay();
        }
    }
    public void startDay()
    {
        /*
        if (Convert.ToBoolean(PlayerPrefs.GetInt("existGame")))
        {
            reputation = PlayerPrefs.GetInt("reputation");
        }
        FindObjectOfType<AudioManager>().Play("gameTheme");
        if (day == 0)
        {
            FindObjectOfType<AudioManager>().Stop("gameTheme");
            introManager.gameObject.SetActive(true);
            return;
        }*/
        kitchenController.updateKitchenElements(day);
        if (day == 6 && clientNum == 0)
        {
            if (!h01 && h05)
            {
                h05 = true;
                clientNum = 2;
                nextClient();
                return;
            }
            if (!h06 && h08)
            {
                h04 = true;
                clientNum = 0;
                nextClient();
                return;
            }
            if (h07)
            {
                h04 = true;
                clientNum = 1;
                nextClient();
                return;
            }            
            clientNum = 3;
            nextClient();
            return;
        }
        nextClient();
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
            saveGame();
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
    public void evaluateCorrectReputation(bool value, bool reseted)
    {
        if (value)
        {
            if (foodPreparator.reject || foodPreparator.foodPreparator2.reject)
            {
                reduceReputation();
                return;
            }
            if (!reseted)
            {
                aumentReputation();
            }
        }
        else
        {
            reduceReputation();
        }
    }
    public void evaluateRejectReputation(bool value)
    {
        if (!value)
        {
            aumentReputation();
        }
        else
        {
            reduceReputation();
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

        day = 0;
        reputation = 10;
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

        day = PlayerPrefs.GetInt("day");
        reputation = PlayerPrefs.GetInt("reputation");

    }
}
