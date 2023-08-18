using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement direction
        Vector3 direction = (Player.transform.position - transform.position).normalized;

        // Calculate the new position based on the direction and speed
        Vector3 newPosition = transform.position + (direction * speed * Time.deltaTime);

        // Move the object to the new position
        transform.position = newPosition;
        
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("CircleLun") || otherCollider.CompareTag("Player"))
        {
            speed = 0f;
        }
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("CircleLun") || otherCollider.CompareTag("Player"))
        {
            speed = 5f;
        }
    }
}
