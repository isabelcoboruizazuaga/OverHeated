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

    public void NewPlatform(GameObject _platformGO)
    {
        GameObject platform = Instantiate(_platformGO, transform);
        // platform.transform.position = new Vector2(transform.position.x, platformSpawn.transform.position.y);

        //platform.GetComponent<Rigidbody2D>().velocity = new Vector3(0,Mathf.Abs(platformSpawn.transform.position.y) + Mathf.Abs(transform.position.y))*-1;


        /*if (Mathf.Abs((platform.transform.position.y - transform.position.y)) < 1)
        {
            platform.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f);
        }*/


    }
    public void PlaySound()
    {
        myAudio.Play();
    }

    public void SetIngredient(bool _ingredient, GameObject _platformGO)
    {
        if (!ingredient)
        {
            ingredient = _ingredient;
            if (ingredient)
            {
                platformGO = _platformGO;
                Instantiate(_platformGO, transform);
                myAudio = _platformGO.GetComponent<AudioSource>();
            }
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
                platformGO = _platfomGo;
                Instantiate(_platfomGo, transform);
                myAudio = _platfomGo.GetComponent<AudioSource>();
            }
        }
    }


    public bool GetIngredient() { return ingredient; }

}
