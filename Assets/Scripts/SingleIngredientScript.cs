using UnityEngine;

public class SingleIngredientScript : MonoBehaviour
{
    [SerializeField] int x, y;
    [SerializeField] bool ingredient;
    public GameObject platformGO;

    public void SetPosition(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public void SetIngredient(bool _ingredient, GameObject _platformGO)
    {
        ingredient = _ingredient;
        if (ingredient)
        {
            platformGO = _platformGO;
            Instantiate(_platformGO, transform);
        }
    }

    public void ChangeIngredient(bool _ingredient = false, GameObject _platfomGo = null)
    {
        if (platformGO != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        if (_ingredient == false)
        {
            ingredient = false;
            platformGO = null;
        }
        else
        {
            if (_platfomGo != null)
            {
                ingredient = true;
                Instantiate(_platfomGo, transform);
                platformGO = _platfomGo;
            }
        }
    }


    public bool GetIngredient() { return ingredient; }

}
