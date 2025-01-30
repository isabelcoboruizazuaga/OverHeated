using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidad")]
    [SerializeField] private float speed;
    [SerializeField] private float smoothTime;

    [Header("Saltar")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool jump = true;
    [SerializeField] private bool doubleJump = true;

    [Header("Sonido")]
    [SerializeField] private AudioSource audioJump;

    private Rigidbody2D rb2D;
    private Vector2 targetVelocity;
    private Vector2 dampVelocity;
    private float p1horizontalInput;

    Animator player_Animator;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player_Animator = gameObject.GetComponent<Animator>();
    }

    bool menuOpen = false;
    private void Update()
    {
        Jump();
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            //This activates the pause
            if (menuOpen)
            {
                GameObject.Find("HUD").GetComponent<MenuController>().CloseMenu();
                menuOpen = false;
            }
            else
            {
                GameObject.Find("HUD").GetComponent<MenuController>().OpenMenu();
                menuOpen = true;
            }
        }
    }

    void FixedUpdate()
    {
        MoveActionP1();

        rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, targetVelocity, ref dampVelocity, smoothTime);
    }

    public void MoveActionP1()
    {
        p1horizontalInput = Input.GetAxis("Horizontal");

        targetVelocity = new Vector2(p1horizontalInput * speed, rb2D.velocity.y);
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && jump)
        {
            jump = false;
            rb2D.AddForce(Vector2.up * jumpForce);
            player_Animator.SetTrigger("jump");
            if (!audioJump.isPlaying) audioJump.Play();
            else
            {
                audioJump.Stop();
            }
        }

        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Joystick1Button0)) && doubleJump)
        {
            doubleJump = false;
            jump = true;
            player_Animator.SetTrigger("jump");
            if (!audioJump.isPlaying) audioJump.Play();
            else
            {
                audioJump.Stop();
            }
        }
    }

    public void Die()
    {
        GameObject.Find("Winning").GetComponent<Winning>().Win(2);
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
