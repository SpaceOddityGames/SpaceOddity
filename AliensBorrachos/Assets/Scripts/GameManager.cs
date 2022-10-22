using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int reputation;
    [SerializeField] private const int maxReputation = 20;
    [SerializeField] private const int reputationAument = 1;
    [SerializeField] private const int reputationReduction = 3;
    [SerializeField] private const int minimumReputation = 5;
    public int day;
    [SerializeField] private ArrayLayout clients;
    private int clientNum;
    void Start()
    {
        startDay();
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
            print("day completed");
            day++;
        }
        else
        {
            print("eres una mierda");
        }
    }
    public void setReputation(int value)
    {
        reputation = value;
    }
    public void evaluateCorrectReputation(bool value)
    {
        if (value)
        {
            aumentReputation();
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
    }
    public void reduceReputation()
    {
        reputation -= reputationReduction;
    }
    public bool evaluateReputation()
    {
        if (reputation < minimumReputation)
        {
            return true;
        }
        else
        {
            return false; //end game
        }
    }
}
