using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private DirectionsUtil.Direction facingDirection;
    [SerializeField]
    private float Speed = 10f;
    [SerializeField]
    private float DircChangeGap;

    private Vector3 movementVector;

    private float DircChangeTimer;

    void Start()
    {
        DircChangeTimer = DircChangeGap;
    }

    void Update()
    {
        if(DircChangeTimer > 0){
            DircChangeTimer -= Time.deltaTime;
        }

        if(DircChangeTimer <= 0){
            facingDirection = (DirectionsUtil.Direction)(((int)facingDirection + Random.Range(-1, 1) + 8)%8);
            DircChangeTimer = DircChangeGap;
        }

        movementVector = DirectionsUtil.DirectionToVector2(facingDirection) * Speed * Time.deltaTime;
    }

    void LateUpdate() 
    {
        movementVector -= (Vector3)InputManager.Instance.CurrentMovementV2 * GameManager.Instance.PlayerSpeed * Time.deltaTime;

        transform.position += movementVector;
    }

    public void setFacingDirect(DirectionsUtil.Direction newDirect){
        facingDirection = newDirect;
    }

    public DirectionsUtil.Direction getFacingDirect(){
        return facingDirection;
    }
}
