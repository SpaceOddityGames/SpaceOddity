using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int day;
    private int[] dayClients;
    [SerializeField] GameObject person;


    void Start()
    {
        GameObject p = Instantiate(person, new Vector3(-510, 0, 0), Quaternion.identity);
        p.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

}
