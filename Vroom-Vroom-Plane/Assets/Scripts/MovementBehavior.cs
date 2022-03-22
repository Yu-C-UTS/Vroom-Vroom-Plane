using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private DirectionsUtil.Direction facingDirection;
    [SerializeField]
    private float Speed = 10f;

    private Vector3 movementVector;

    void Start()
    {
        facingDirection = DirectionsUtil.Direction.Right;
    }

    void Update()
    {
        movementVector = DirectionsUtil.DirectionToVector2(facingDirection) * Speed * Time.deltaTime;
    }

    void LateUpdate() 
    {
        movementVector -= (Vector3)InputManager.Instance.CurrentMovementV2 * GameManager.Instance.PlayerSpeed * Time.deltaTime;

        transform.position += movementVector;
    }
}
