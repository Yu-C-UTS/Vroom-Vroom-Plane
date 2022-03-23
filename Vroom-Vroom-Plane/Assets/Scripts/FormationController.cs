using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBehavior))]
public class FormationController : MonoBehaviour
{
    private MovementBehavior movementBehavior;

    [SerializeField]
    private float MinTurnDelay = 2f;
    [SerializeField]
    private float MaxTurnDelay = 5f;
    private float TurnTimer;

    private void Awake() 
    {
        movementBehavior = GetComponent<MovementBehavior>();
        if(movementBehavior == null)
        {
            Debug.LogError("No Movement Behavior found");
        }    
    }

    private void Start() 
    {
        ResetTurnTimer();
    }

    private void Update() 
    {
        TurnUpdate();
    }

    private void TurnUpdate()
    {
        TurnTimer -= Time.deltaTime;

        if(TurnTimer <= 0)
        {
            Turn();
        }
    }

    private void ResetTurnTimer()
    {
        TurnTimer = Random.Range(MinTurnDelay, MaxTurnDelay);
    }

    private void Turn()
    {
        int turnDirection = Random.Range(0, 2);
        if(turnDirection == 0)
        {
            TurnLeft();
        }
        else
        {
            TurnRight();
        }

        ResetTurnTimer();
    }

    private void TurnLeft()
    {
        movementBehavior.FacingDirection = (DirectionsUtil.Direction)(((int)movementBehavior.FacingDirection - 1 + 8)%8);
    }

    private void TurnRight()
    {
        movementBehavior.FacingDirection = (DirectionsUtil.Direction)(((int)movementBehavior.FacingDirection + 1 + 8)%8);
    }
}
