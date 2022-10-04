using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] Text DialogText;
    [SerializeField] Image DialogBox;
    [SerializeField] Button text1;
    [SerializeField] Button text2;
    void Start()
    {
        text1.onClick.AddListener(() => sendText1());
        text2.onClick.AddListener(() => sendText2());
    }

    private void sendText1()
    {
        //DialogText.GetComponent<Text>().text = "casa";
        DialogText.text = "casa";
    }
    private void sendText2()
    {
        //DialogText.GetComponent<TextMesh>().text = "puta";
        DialogText.text = "casdasda";
    }
}
