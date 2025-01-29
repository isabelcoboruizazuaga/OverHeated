using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Break());
        }
    }

    IEnumerator Break()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,2f));
        gameObject.GetComponent<Animator>().SetTrigger("break1");

        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        gameObject.GetComponent<Animator>().SetTrigger("total");

        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponentInParent<SingleIngredientScript>().DestroyPlatform();

    }
}
