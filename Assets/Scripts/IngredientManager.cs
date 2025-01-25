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

    [SerializeField] private int bombAmount;





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

   private void SetIngredients()
    {
        int aux = 0; 
        for (int i = 0; i < 8 && aux < 1000; i++)
        {
            aux++;

            int randomX = Random.Range(0, width);
            int randomY = Random.Range(0, height);

            if (CheckAround(randomX, randomY) <2) //si es 2 o más hay al menos dos ingredientes en línea
            {
                map[randomX, randomY].SetIngredient(true);
            }

            else i--;
        }
    }

    private int CheckAround(int x, int y)
    {
        int aux = 0;
        //casillas de la izquierda
        if (x > 0                               /**/&& map[x - 1, y].GetBomb())
        {
            aux++;

            if ((x-1) > 1                               /**/&& map[x - 2, y].GetBomb()) aux++;
        }


        //casillas de la derecha
        if (x < (width - 1)                     /**/&& map[x + 1, y].GetBomb())
        {
            aux++;

            if ((x + 1) < (width - 2)                     /**/&& map[x + 2, y].GetBomb()) aux++;
        }

        //esa linea vertical
        if (y > 0                               /**/&& map[x, y - 1].GetBomb()) {
            aux++;

            if (y-1 > 0                               /**/&& map[x, y - 2].GetBomb()) aux++;
        }


        if (y < (height - 1)                    /**/&& map[x, y + 1].GetBomb())
        {
            aux++;

            if (y-1 < (height - 2)                    /**/&& map[x, y + 2].GetBomb()) aux++;
        }

        if (map[x, y].GetBomb()) aux++;

        return aux;

    }
    public int BombsAround(int x, int y)
    {
        int aux = 0;
        //casillas de la izquierda
        if (x > 0                               /**/&& map[x - 1, y].GetBomb()) aux++;
        if (x > 0 && y > 0                      /**/&& map[x - 1, y - 1].GetBomb()) aux++;
        if (x > 0 && y < (height - 1)           /**/&& map[x - 1, y + 1].GetBomb()) aux++;

        //casillas de la derecha
        if (x < (width - 1) && y > 0            /**/&& map[x + 1, y - 1].GetBomb()) aux++;
        if (x < (width - 1) && y < (height - 1) /**/&& map[x + 1, y + 1].GetBomb()) aux++;
        if (x < (width - 1)                     /**/&& map[x + 1, y].GetBomb()) aux++;

        //esa linea vertical
        if (y > 0                               /**/&& map[x, y - 1].GetBomb()) aux++;
        if (y < (height - 1)                    /**/&& map[x, y + 1].GetBomb()) aux++;
        if (map[x, y].GetBomb()) aux++;

        return aux;
    }

    void SetBombs()
    {
        int aux = 0;
        for (int i = 0; i < bombAmount && aux < 1000; i++)
        {
            aux++;

            int randomX = Random.Range(0, width);
            int randomY = Random.Range(0, height);

            if (!map[randomX, randomY].GetBomb()) map[randomX, randomY].SetIngredient(true);
            else i--;
        }
    }

}
