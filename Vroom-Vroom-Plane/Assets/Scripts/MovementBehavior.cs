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

    }

    void Update()
    {
        movementVector = DirectionsUtil.V2toV3YZSwap(DirectionsUtil.DirectionToVector2(facingDirection)) * Speed * Time.deltaTime;
    }

    void LateUpdate() 
    {
        movementVector -= InputManager.Instance.CurrentMovementV3 * GameManager.Instance.PlayerSpeed * Time.deltaTime;

        transform.position += movementVector;
    }
}
