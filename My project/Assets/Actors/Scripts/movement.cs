using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;

    
    private Vector2Int targetPosition;
 
    private void Awake()
    {
        // Set t$$anonymous$$s so we don't wander off at the start
        targetPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
        transform.position = (Vector2)targetPosition;
    }

    private void Update()
    {
        var moving = (Vector2)transform.position != targetPosition;

        if (moving)
        {
            MoveTowardsTargetPosition();
        }
        else
        {
            SetNewTargetPositionFromInput();
        }
    }

    private void MoveTowardsTargetPosition()
    {
       transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void SetNewTargetPositionFromInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            targetPosition += Vector2Int.up;
        }
        else if(Input.GetKey(KeyCode.A))
        {
           targetPosition += Vector2Int.left;
        }
        else if(Input.GetKey(KeyCode.S))
        {
           targetPosition += Vector2Int.down;
        }
        else if(Input.GetKey(KeyCode.D))
        {
           targetPosition += Vector2Int.right;
        }
    }
}

