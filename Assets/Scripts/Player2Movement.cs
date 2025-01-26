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

    Animator player_Animator;


    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player_Animator = GetComponent<Animator>();
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
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKey(KeyCode.KeypadEnter)) && jump)
        {
            jump = false;
            rb2D.AddForce(Vector2.up * jumpForce);
            player_Animator.SetTrigger("jump");
        }

        if ((Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Joystick2Button0) || Input.GetKeyUp(KeyCode.KeypadEnter)) && doubleJump)
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

