using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletButton : MonoBehaviour
{
    [SerializeField] GameObject tablet;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] LiquidIngredient[] liquids;
    [SerializeField] TutorialManager tutorial;
    [SerializeField] PostitButton postit;
    [SerializeField] GameObject botonApagado;
    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool inactive = false;
    [HideInInspector] public bool tutorialActive = false;
    private void Start()
    {
        tutorialActive = false;
    }
    public void OnMouseDown()
    {
        if (!paused && !inactive)
        {
            postit.inactive = true;
            FindObjectOfType<AudioManager>().Play("abrirTablet");
            tablet.SetActive(true);
            botonApagado.GetComponent<Button>().interactable = true;
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].disable();
            }
            for (int i = 0; i < liquids.Length; i++)
            {
                liquids[i].disable();
            }
            if (tutorialActive && !paused)
            {
                if (FindObjectOfType<TutorialManager>() != null)
                {
                    tutorial.nextText();
                }
                tutorialActive = false;
            }
            this.gameObject.SetActive(false);
        }
    }
    public void enableIngredients()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].enable();
        }
        for (int i = 0; i < liquids.Length; i++)
        {
            liquids[i].enable();
        }
    }
}

