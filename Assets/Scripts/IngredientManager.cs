using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientManager : MonoBehaviour
{
    public static IngredientManager instance;

    [SerializeField] private GameObject buttonObject;
    [SerializeField] private Transform panelGame;

    [SerializeField] int width = 4, height = 3;
    private static SingleIngredientScript[,] map;

    [SerializeField] private int platformAmount;

    [SerializeField] GameObject[] ingredientsSprite;

    private void Awake()
    {
        instance = this;

        map = new SingleIngredientScript[width, height];

    }
    void Start()
    {
        int aux = 0;
        SingleIngredientScript[] ingredientScript= gameObject.GetComponentsInChildren<SingleIngredientScript>();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                map[x, y] = ingredientScript[aux];
                map[x, y].SetPosition(x, y);

                aux++;
            }
        }
       SetIngredients();
    }

    private GameObject GetRandomPlatform()
    {
        return ingredientsSprite[Random.Range(0, ingredientsSprite.Length)];
    }

   private void SetIngredients()
    {
        int aux = 0; 
        for (int i = 0; i < platformAmount && aux < 1000; i++)
        {
            aux++;

            int randomX = Random.Range(0, width);
            int randomY = Random.Range(0, height);

            if (CheckAround(randomX, randomY) <2 && !map[randomX, randomY].GetIngredient() ) //si es 2 o más hay al menos dos ingredientes en línea
            {
                map[randomX, randomY].SetIngredient(true, GetRandomPlatform());
            }

            else i--;
        }
    }

    private int CheckAround(int x, int y)
    {
        int aux = 0;
        //casillas de la izquierda
        if (x > 0                               /**/&& map[x - 1, y].GetIngredient())
        {
            aux++;

            if ((x-1) > 1                               /**/&& map[x - 2, y].GetIngredient()) aux++;
        }


        //casillas de la derecha
        if (x < (width - 1)                     /**/&& map[x + 1, y].GetIngredient())
        {
            aux++;

            if ((x + 1) < (width - 2)                     /**/&& map[x + 2, y].GetIngredient()) aux++;
        }

        //esa linea vertical
        if (y > 0                               /**/&& map[x, y - 1].GetIngredient()) {
            aux++;

            if (y-1 > 0                               /**/&& map[x, y - 2].GetIngredient()) aux++;
        }


        if (y < (height - 1)                    /**/&& map[x, y + 1].GetIngredient())
        {
            aux++;

            //if (y-1 < (height - 2)                    /**/&& map[x, y + 2].GetIngredient()) aux++;
        }

        return aux;

    }
    

}
