using UnityEngine;

public class PlatformDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            if (gameObject.GetComponentInParent<Rigidbody2D>().velocity.y < 3) //this avoid launching on platforms, player must come 
            {
                if (transform.parent.gameObject.name == "Player1")
                {

                    this.gameObject.GetComponentInParent<PlayerMovement>().SetJump(true);
                    this.gameObject.GetComponentInParent<PlayerMovement>().SetDoubleJump(true);
                }
                else
                {
                    this.gameObject.GetComponentInParent<Player2Movement>().SetJump(true);
                    this.gameObject.GetComponentInParent<Player2Movement>().SetDoubleJump(true);
                }
            }
        }
    }
}
