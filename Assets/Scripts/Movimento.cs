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

    void Update()
    {
        ManejoMovimento();
        Pulo();
    }

    void ManejoMovimento()
    {
        transform.rotation = Quaternion.identity;
        float inputHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = Time.deltaTime * velocidade * new Vector2(inputHorizontal, 0);
        myRigidBody.position += movement;
    }
    void Pulo()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = 2 * pulo * Vector2.up;
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 normal = collision.contacts[0].normal;

        if (normal == Vector2.up && collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Colisão");
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Saiu do chão");
        Invoke("ResetGrounded", jumpGracePeriod);
    }
    void ResetGrounded()
    {
        isGrounded = false;
        Debug.Log("Grace acabou");
    }
}