using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    [SerializeField] float velocidade = 6f;
    [SerializeField] float pulo = 3f;
    public bool isGrounded;
    [SerializeField] public float jumpGracePeriod;
    private Animator anim;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    public bool isJumping = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * 5, rb.velocity.y);
        rb.velocity = movement;

        // Atualizar parâmetro "Speed" no Animator
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 3);
            // Ativar trigger "Jump" no Animator
            anim.SetBool("Jumping", true);
            StartCoroutine(Wait());
            anim.SetBool("Jumping", false);
        }
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flipping the sprite by negating the X scale
        transform.localScale = scale;
    }
}