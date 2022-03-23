using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBehavior))]
public class FormationController : MonoBehaviour
{
    private MovementBehavior movementBehavior;
    
    [SerializeField]
    public Transform partent;
    [SerializeField]
    private float MinTurnDelay = 2f;
    [SerializeField]
    private float MaxTurnDelay = 5f;
    private float TurnTimer;
    private float soomth = 1.0f;
    private DirectionsUtil.Direction NextFacingDirection;

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
        NextFacingDirection = movementBehavior.FacingDirection;
    }

    private void Update() 
    {
        TurnUpdate();
        UpdateFormation();
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
            Quaternion rotation = Quaternion.Euler(transform.root.rotation.x, transform.root.rotation.y, transform.root.rotation.z + 45);
            transform.root.rotation = Quaternion.Slerp(transform.root.rotation, rotation,  Time.deltaTime * soomth);
        }
        else
        {
            TurnRight();
            Quaternion rotation = Quaternion.Euler(transform.root.rotation.x, transform.root.rotation.y, transform.root.rotation.z - 45);
            transform.root.rotation = Quaternion.Slerp(transform.root.rotation, rotation,  Time.deltaTime * soomth);
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

    private void UpdateFormation(){
        NextFacingDirection = movementBehavior.FacingDirection;
        Quaternion rotation = Quaternion.Euler(partent.rotation.x, partent.rotation.y, DirectionsUtil.DirectionToRotation(NextFacingDirection));
        partent.rotation = Quaternion.Slerp(partent.rotation, rotation,  Time.deltaTime * soomth);
    }
}
