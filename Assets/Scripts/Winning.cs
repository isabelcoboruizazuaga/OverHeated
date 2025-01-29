using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    [SerializeField] GameObject panelEnd;
    [SerializeField] GameObject img1, img2;


    private void Start()
    {
        panelEnd.SetActive(false);
        img1.SetActive(false);
        img2.SetActive(false);
        lp1=false; lp2=false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panelEnd.SetActive(true);

            if (GameObject.Find("Player1").GetComponent<Collider2D>().enabled)
            {
                img1.SetActive(true);
            }
            if (GameObject.Find("Player2").GetComponent<Collider2D>().enabled)
            {
                img2.SetActive(true);
            }

            StartCoroutine(Reload());
        }
    }

    private bool lp1, lp2;
    public void Win(int player)
    {
        if(player == 1)
        {
            panelEnd.SetActive(true);
            img1.SetActive(true);
            lp2 = true;
        }
        else if(player == 2)
        {
            panelEnd.SetActive(true);
            img2.SetActive(true);
            lp1 = true;
        }
        if(lp1 && lp2)
        {
            img1.SetActive(false);
            img2.SetActive(false);
        }

        StartCoroutine(Reload());
    }
    private void Update()
    {
        if (!GameObject.Find("Player1").GetComponent<Collider2D>().enabled && !GameObject.Find("Player2").GetComponent<Collider2D>().enabled)
        {
            panelEnd.SetActive(true);
            img2.SetActive(false);
            img1.SetActive(false);
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("01game");
    }
}
