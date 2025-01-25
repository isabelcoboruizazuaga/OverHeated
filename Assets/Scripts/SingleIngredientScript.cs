using UnityEngine;

public class SingleIngredientScript : MonoBehaviour
{
    [SerializeField] int x, y;

    [SerializeField] bool ingredient;

    public void SetPosition(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public void SetIngredient(bool _ingredient,Sprite sprite) { 
        ingredient = _ingredient;
        if(ingredient)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        }
    }

    public bool GetIngredient() { return ingredient; }

}
