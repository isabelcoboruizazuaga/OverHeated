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

    public void SetIngredient(bool _ingredient,GameObject platformGO) { 
        ingredient = _ingredient;
        if(ingredient)
        {
            Instantiate(platformGO,transform);
            //gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        }
    }

    public bool GetIngredient() { return ingredient; }

}
