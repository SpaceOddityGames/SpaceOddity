using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletButton : MonoBehaviour
{
    [SerializeField] GameObject tablet;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] LiquidIngredient[] liquids;
    [SerializeField] TutorialManager tutorial;
    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool tutorialActive = false;
    public void OnMouseDown()
    {
        if (!paused)
        {
            tablet.SetActive(true);
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].disable();
            }
            for (int i = 0; i < liquids.Length; i++)
            {
                liquids[i].disable();
            }
            this.gameObject.SetActive(false);
        }
        if (tutorialActive)
        {
            tutorial.nextText();
            tutorialActive = false;
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

