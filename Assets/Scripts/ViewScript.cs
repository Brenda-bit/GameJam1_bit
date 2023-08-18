using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ViewScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private RectTransform canvasCollisionArea;

    private void Start()
    {
        // Find the canvas collision area
        canvasCollisionArea = GameObject.Find("CanvasCollider").GetComponent<RectTransform>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

        // Check if the new position is within the canvas collision area
        if (IsPositionInsideCanvasCollisionArea(newPosition))
        {
            transform.position = newPosition;
        }
    }

    private bool IsPositionInsideCanvasCollisionArea(Vector3 position)
    {
        // Convert world position to canvas screen position
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(null, position);

        // Check if the screen position is within the canvas collision area's rectangle
        return RectTransformUtility.RectangleContainsScreenPoint(canvasCollisionArea, screenPosition);
    }
}

