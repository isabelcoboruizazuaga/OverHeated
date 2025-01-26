using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    [SerializeField] GameObject panelEnd;
    [SerializeField] GameObject img1, img2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panelEnd.SetActive(true);

            if (GameObject.Find("Player1").GetComponent<Collider2D>().enabled)
            {
                img1.SetActive(true);
                img2.SetActive(false);
            }
            if (GameObject.Find("Player2").GetComponent<Collider2D>().enabled)
            {
                img2.SetActive(true);
                img1.SetActive(false);
            }

        }
    }

    private void Update()
    {
        if (!GameObject.Find("Player1").GetComponent<Collider2D>().enabled && !GameObject.Find("Player2").GetComponent<Collider2D>().enabled)
        {
            panelEnd.SetActive(true);
            img2.SetActive(false);
            img1.SetActive(false);
        }
    }
}
