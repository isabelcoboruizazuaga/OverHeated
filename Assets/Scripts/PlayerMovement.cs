using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player")]
    public bool player1 = true;

    [Header("Velocidad")]
    [SerializeField] private float speed;
    [SerializeField] private float smoothTime;

    [Header("Saltar")]
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb2D;
    private Vector2 targetVelocity;
    private Vector2 dampVelocity; //required by unity
    private float p1horizontalInput, p2horizontalInput;


    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (player1)
        {
            MoveActionP1();
            JumpP1();
        }
        else
        {
            MoveActionP2();
            JumpP2();
        }

        rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, targetVelocity, ref dampVelocity, smoothTime); //the ref means its the damp velocity, not a copy, its being modified constantly

    }

    public void MoveActionP1()
    {
        p1horizontalInput = Input.GetAxis("Horizontal");

        targetVelocity = new Vector2(p1horizontalInput * speed, rb2D.velocity.y);
    }
    public void MoveActionP2()
    {
        p2horizontalInput = Input.GetAxis("Vertical");

        targetVelocity = new Vector2(p2horizontalInput * speed, rb2D.velocity.y);
    }

    private void JumpP1()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb2D.AddForce(Vector2.up * jumpForce);
        //rb2D.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
    }

    private void JumpP2()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            rb2D.AddForce(Vector2.up * jumpForce);
        //rb2D.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
    }

}
