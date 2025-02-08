using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Movement : MonoBehaviour
{
    [Header("Velocidad")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float smoothTime = 0.1f;

    [Header("Saltar")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool jump = true;
    private bool doubleJump = true;

    [Header("Sonido")]
    [SerializeField] private AudioSource audioJump;

    private Rigidbody2D rb2D;
    private Vector2 targetVelocity;
    private Vector2 dampVelocity;
    private float horizontalInput;


    private Animator player_Animator;
    private PlayerInput playerInput;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player_Animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }


    // Ahora la parte de movimiento esta en visual scripting, lo siento :( (podriamos probar a cambiarlo a C# tb)

    //void FixedUpdate()
    //{
    //    Move();
    //    rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, targetVelocity, ref dampVelocity, smoothTime);
    //}

    // Manejo del movimiento con New Input System
    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    horizontalInput = context.ReadValue<Vector2>().x;
    //}

    //private void Move()
    //{

    //    targetVelocity = new Vector2(horizontalInput * speed, rb2D.velocity.y);
    //}

    // El doble salto ha dejado de funcionar pero ironicamente en el 1er jugador si fufa

    //public void OnJump()
    //{
    //    if (jump)
    //    {
    //        Debug.Log("jump1");
    //        jump = false;
    //        rb2D.AddForce(Vector2.up * jumpForce);
    //        player_Animator.SetTrigger("jump")
    //        if (doubleJump == true && jump == false &&)
    //        {
    //            Debug.Log("jump2");
    //            doubleJump = false;
    //            jump = false;
    //            rb2D.AddForce(Vector2.up * jumpForce);
    //            player_Animator.SetTrigger("jump");
    //            if (!audioJump.isPlaying) audioJump.Play();
    //            else
    //            {
    //                audioJump.Stop();
    //            }
    //        }
    //        if (!audioJump.isPlaying) audioJump.Play();
    //        else
    //        {
    //            audioJump.Stop();
    //        }


    //    }

    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Platform"))
    //    {
    //        jump = true;
    //        doubleJump = true;
    //    }
    //}

    public void Die()
    {
        GameObject.Find("Winning").GetComponent<Winning>().Win(1);
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
