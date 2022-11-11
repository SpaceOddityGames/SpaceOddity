using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int reputation;
    [SerializeField] public int maxReputation = 20;
    [SerializeField] private const int reputationAument = 1;
    [SerializeField] private const int reputationReduction = 3;
    [SerializeField] private const int minimumReputation = 5;
    public int day;
    [SerializeField] private ArrayLayout clients;
    private int clientNum;
    [SerializeField] Endings endManager;
    [SerializeField] KitchenController kitchenController;
    [SerializeField] FoodPreparation foodPreparator;
    [SerializeField] Slider reputationSlider;

    // Evolución de la partida
    [HideInInspector] public bool h01 = false;
    [HideInInspector] public bool h02 = false;
    [HideInInspector] public bool h03 = false;
    [HideInInspector] public bool h04 = false;
    [HideInInspector] public bool h05 = false;
    [HideInInspector] public bool h06 = false;
    [HideInInspector] public bool h07 = false;
    [HideInInspector] public bool h08 = false;

    void Start()
    {
        startDay();
        kitchenController.updateKitchenElements(day);
        reputationSlider.maxValue = maxReputation;
        updateSliderBar();
    }
    public void nextClient()
    {
        if (clientNum < clients.Day[day].Client.Length)
        {
            GameObject p = Instantiate(clients.Day[day].Client[clientNum], new Vector3(92, 0, 2), Quaternion.Euler(90,180,0));
            clientNum++;
        }
        else
        {
            endDay();
        }
    }
    public void startDay()
    {
        nextClient();
    }
    public void endDay()
    {
        if (evaluateReputation())
        {
            day++;
            if (reputation > maxReputation)
            {
                reputation = maxReputation;
            }
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
        updateSliderBar();
    }
    public void reduceReputation()
    {
        reputation -= reputationReduction;
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
}
