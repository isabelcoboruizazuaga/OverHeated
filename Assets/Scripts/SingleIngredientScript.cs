using UnityEngine;

public class SingleIngredientScript : MonoBehaviour
{
    [SerializeField] int x, y;
    [SerializeField] bool ingredient=false;
    public GameObject platformGO;
    GameObject platformSpawn;

    [Header("Sonido")]
    [SerializeField] private AudioSource myAudio;

    private void Start()
    {
        platformSpawn = GameObject.Find("IngredientSpawner");
    }
    public void SetPosition(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public void SetIngredient(bool _ingredient, GameObject _platformGO, bool visible)
    {
        if (!ingredient)
        {
            ingredient = _ingredient;
            if (ingredient)
            {
                platformGO = _platformGO;
                Instantiate(_platformGO, transform);
               // _platformGO.GetComponent<SpriteRenderer>().enabled = visible;

            }
        }
    }

    public void ChangeIngredient(bool _ingredient = false, GameObject _platfomGo = null)
    {
        DestroyPlatform();
        SetIngredient(_ingredient, _platfomGo,true);
    }

    public void DestroyPlatform()
    {
        if (platformGO != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        ingredient = false;
        platformGO = null;

    }


    public bool GetIngredient() { return ingredient; }

}
