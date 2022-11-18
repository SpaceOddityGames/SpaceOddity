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
    [SerializeField] Introduction introManager;
    [SerializeField] KitchenController kitchenController;
    [SerializeField] FoodPreparation foodPreparator;
    [SerializeField] Slider reputationSlider;

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
            GameObject p = Instantiate(clients.Day[day].Client[clientNum], new Vector3(92, 0, 2), Quaternion.Euler(90, 180, 0));
            clientNum++;
        }
        else
        {
            endDay();
        }
    }
    public void startDay()
    {
        if(day == 0)
        {
            introManager.gameObject.SetActive(true);
            return;
        }
        if(day == 6 && clientNum == 0)
        {
            if (!h01 && h05)
            {
                clientNum = 2;
                nextClient();
                return;
            }
            if (!h06 && !h08)
            {
                clientNum = 0;
                h04 = true;
                nextClient();
                return;
            }
            if (h07)
            {
                clientNum = 1;
                h04 = true;
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
        clientNum = 0;
        if (evaluateReputation())
        {
            day++;
            if (reputation > maxReputation)
            {
                reputation = maxReputation;
            }
            saveGame();
            endManager.endDay(true);
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
        updateSliderBar();
    }
    public void reduceReputation()
    {
        reputation -= reputationReduction;
        FindObjectOfType<AudioManager>().Play("reputacionDown");
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
        PlayerPrefs.SetInt("h09", Convert.ToInt32(h08));

        PlayerPrefs.SetInt("day", day);
        PlayerPrefs.SetInt("reputation", reputation);
    }
    public void loadGame()
    {
        h01 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h02 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h03 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h04 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h05 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h06 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h07 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h08 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));
        h09 = Convert.ToBoolean(PlayerPrefs.GetInt("h01"));

        day = PlayerPrefs.GetInt("day");
        reputation = PlayerPrefs.GetInt("reputation");

    }
}
