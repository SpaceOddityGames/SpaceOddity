using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    private const int LIST_SIZE = 10;
    public int[][] recetas;
    public GameObject bowl;
    private void Start()
    {
        recetas = new int[LIST_SIZE][];
        //Lista de recetas
        int[] receta1 = { 1, 2, 3, 0, 0 };
        int[] receta2 = { 2, 3, 4, 0, 0 };
        int[] receta3 = { 1, 4, 0, 0, 0 };
        int[] receta4 = { 1, 2, 3, 4, 0 };
        recetas[0] = receta1;
        recetas[1] = receta2;
        recetas[2] = receta3;
        recetas[3] = receta4;

    }
    public void createTask(int i)
    {
        //bowl.GetComponent<FoodPreparation>().SetObjective(recetas[i]);
    }
    private void OnMouseDown()
    {
        int i = Random.Range(0, 4);
        createTask(i);
    }
}
