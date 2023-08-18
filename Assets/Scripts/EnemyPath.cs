using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    public float arrivalThreshold = 0.1f;
    void Start()
    {
       rb= GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the movement direction
        Vector2 direction = (currentPoint.position - transform.position).normalized;

        // Calculate the new position based on the direction and speed
        Vector2 newPosition = (Vector2)transform.position + (direction * speed * Time.deltaTime);

        // Move the object to the new position
        transform.position = newPosition;

        float distanceToTarget = Vector2.Distance(transform.position, currentPoint.position);

        if (currentPoint == pointB.transform && distanceToTarget <= arrivalThreshold)
        {
            currentPoint = pointA.transform;
            Debug.Log("Here");
        }
        else if(currentPoint == pointA.transform && distanceToTarget <= arrivalThreshold)
        {
            currentPoint = pointB.transform;
        }
    }
       
}
