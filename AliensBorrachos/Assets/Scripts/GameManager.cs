using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        day++;
    }

}
