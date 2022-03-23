using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBehavior))]
public class Parachute : MonoBehaviour
{
    private MovementBehavior movementBehavior;

    [SerializeField]
    private float _parachuteSpeed = 3f;

    [SerializeField, Range(0,1)]
    private float parachuteShrinkSpeed = 0.9f;

    public DirectionsUtil.Direction ParachuteDirection
    {
        get
        {
            return movementBehavior.FacingDirection;
        }
        set
        {
            movementBehavior.FacingDirection = value;
        }
    }
    public float ParachuteSpeed
    {
        get
        {
            return movementBehavior.Speed;
        }
        set
        {
            _parachuteSpeed = value;
            movementBehavior.Speed = value;
        }
    }

    private void Awake() 
    {
        movementBehavior = GetComponent<MovementBehavior>();
        if(movementBehavior == null)
        {
            Debug.LogError("No Movement Behavior Found");
        }    
        movementBehavior.Speed = _parachuteSpeed;
    }

    private void Update() 
    {
        parachuteShrinkUpdate();
    }

    private void parachuteShrinkUpdate()
    {
        transform.localScale *= Mathf.Pow(parachuteShrinkSpeed, Time.deltaTime);
        if(transform.localScale.magnitude <= 0.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        PlayerUnit CollidedPlayerUnit = other.gameObject.GetComponent<PlayerUnit>();
        
        //Collided with something that is not a player unit(plane), ignoring collision
        if(CollidedPlayerUnit == null)
        {
            return;
        }    

        playerPickup();
    }

    private void playerPickup()
    {
        GameManager.Instance.PlayerScore += 500;
        Destroy(gameObject);
    }
}
