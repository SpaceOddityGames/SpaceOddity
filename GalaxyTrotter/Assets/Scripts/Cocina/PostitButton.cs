using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostitButton : MonoBehaviour
{
    [SerializeField] GameObject postit;
    [SerializeField] TabletButton tablet;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] LiquidIngredient[] liquids;
    [HideInInspector] public bool paused = false;
    [HideInInspector] public bool inactive = false;

    public void OnMouseDown()
    {
        if (!paused || !inactive)
        {
            tablet.inactive = true;
            postit.SetActive(true);
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
    }
}
