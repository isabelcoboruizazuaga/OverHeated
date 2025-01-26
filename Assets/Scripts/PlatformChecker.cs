using System.Collections;
using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    bool change = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") && (collision.transform.name != "Square" && !collision.transform.name.Contains("urbuja")))
        {
            if (change)
            {
                collision.transform.GetComponentInParent<IngredientManager>().DownIngredients();
                change = false;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        change = true;
    }
}
