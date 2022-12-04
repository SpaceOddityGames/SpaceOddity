using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Postit : MonoBehaviour
{
    [SerializeField] GameObject textArea;
    [SerializeField] GameObject newObj;
    [SerializeField] GameObject postit;
    [SerializeField] TabletButton tabletButton;
    public void addNote(string name)
    {
        GameObject p = Instantiate(newObj, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        p.transform.SetParent(textArea.transform);
        p.GetComponent<TextMeshProUGUI>().text = " -   " + name;
        p.transform.localScale = new Vector3(1, 1, 1);
    }
    public void eliminateNote()
    {
        for (int i = textArea.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(textArea.transform.GetChild(i).gameObject);
        }
    }
    public void closePostit()
    {
        FindObjectOfType<KitchenController>().enableAll();
        tabletButton.inactive = false;
        postit.SetActive(true);
        this.gameObject.SetActive(false);        
    }
}
