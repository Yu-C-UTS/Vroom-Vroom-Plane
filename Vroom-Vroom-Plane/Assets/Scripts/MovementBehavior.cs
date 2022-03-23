using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    [SerializeField]
    private DirectionsUtil.Direction _facingDirection;
    public DirectionsUtil.Direction FacingDirection
    {
        get
        {
            return _facingDirection;
        }
        set
        {
            _facingDirection = value;
        }
    }

    [SerializeField]
    private float _speed = 10f;
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    // [SerializeField]
    // private float DircChangeGap;

    private Vector3 movementVector;

    // private float DircChangeTimer;

    void Start()
    {
        // DircChangeTimer = DircChangeGap;
    }

    void Update()
    {
        // if(DircChangeTimer > 0){
        //     DircChangeTimer -= Time.deltaTime;
        // }

        // if(DircChangeTimer <= 0){
        //     _facingDirection = (DirectionsUtil.Direction)(((int)_facingDirection + Random.Range(-1, 2) + 8)%8);
        //     DircChangeTimer = DircChangeGap;
        // }

        movementVector = DirectionsUtil.DirectionToVector2(_facingDirection) * _speed * Time.deltaTime;
        if(Vector3.Distance(transform.position, new Vector3(0,0,0)) > 30){
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void LateUpdate() 
    {
        movementVector -= (Vector3)InputManager.Instance.CurrentMovementV2 * GameManager.Instance.PlayerSpeed * Time.deltaTime;

        transform.position += movementVector;
    }

    // public void setFacingDirect(DirectionsUtil.Direction newDirect){
    //     _facingDirection = newDirect;
    // }

    // public DirectionsUtil.Direction getFacingDirect(){
    //     return _facingDirection;
    // }
}
