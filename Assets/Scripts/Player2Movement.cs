using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [Header("Velocidad")]
    [SerializeField] private float speed;
    [SerializeField] private float smoothTime;

    [Header("Saltar")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool jump = true;
    private bool doubleJump = true;

    private Rigidbody2D rb2D;
    private Vector2 targetVelocity;
    private Vector2 dampVelocity;
    private float p2horizontalInput;


    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        MoveActionP1();

        rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, targetVelocity, ref dampVelocity, smoothTime);
    }

    public void MoveActionP1()
    {
        p2horizontalInput = Input.GetAxis("Vertical");

        targetVelocity = new Vector2(p2horizontalInput * speed, rb2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Return) && jump)
        {
            jump = false;
            rb2D.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Return) && doubleJump)
        {
            doubleJump = false;
            jump = true;
        }
    }

    public void SetJump(bool jump)
    {
        this.jump = jump;
    }
    public void SetDoubleJump(bool doubleJump)
    {
        this.doubleJump = doubleJump;
    }
}

