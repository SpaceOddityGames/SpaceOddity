using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class prueba : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public int num = 0;

    public void add()
    {
        num++;
    }
    public void Update()
    {
        text.text = num.ToString();
    }

    public void save()
    {
        PlayerPrefs.SetInt("num", num);
        PlayerPrefs.Save();
    }
    public void load()
    {
        num = PlayerPrefs.GetInt("num");
    }
}
