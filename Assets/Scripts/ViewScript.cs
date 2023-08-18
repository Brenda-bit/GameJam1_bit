using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ViewScript : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private RectTransform canvasCollisionArea;
    private Vector3 targetPosition;
    private void Start()
    {
        // Find the canvas collision area
        canvasCollisionArea = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Calculate the target position with a delay
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z += Camera.main.nearClipPlane;
        targetPosition = Vector3.Lerp(targetPosition, cursorPosition, Time.deltaTime * moveSpeed);

        // Check if the new position is within the canvas collision area
        if (IsPositionInsideCanvasCollisionArea(targetPosition))
        {
            transform.position = targetPosition;
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

