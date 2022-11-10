using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabletButton: MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject recipes;
    [SerializeField] GameObject closeButton;
    [SerializeField] public GameObject paNoVerElFondo;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] LiquidIngredient[] liquids;
    [SerializeField] TutorialManager tutorial;
    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool tutorialActive = false;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (!paused)
        {
            this.gameObject.SetActive(false);
            paNoVerElFondo.SetActive(true);
            recipes.SetActive(true);
            closeButton.SetActive(true);
            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].disable();
            }
            for (int i = 0; i < liquids.Length; i++)
            {
                liquids[i].disable();
            }
        }
        if (tutorialActive)
        {
            tutorial.nextText();
        }
    }
}
