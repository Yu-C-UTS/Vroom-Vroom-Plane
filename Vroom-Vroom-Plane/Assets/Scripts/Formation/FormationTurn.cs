using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationTurn : MonoBehaviour
{
    private float soomth = 1.0f;
    public Transform partent;
    private DirectionsUtil.Direction NextFacingDirection;
    private MovementBehavior movementBehavior;
    // Start is called before the first frame update
    void Start()
    {
        movementBehavior = GetComponent<MovementBehavior>();
        if(movementBehavior == null)
        {
            Debug.LogError("No Movement Behavior found");
        }
        NextFacingDirection = movementBehavior.FacingDirection;
    }

    // Update is called once per frame
    void Update()
    {
        NextFacingDirection = movementBehavior.FacingDirection;
        Quaternion rotation = Quaternion.Euler(partent.rotation.x, partent.rotation.y, DirectionsUtil.DirectionToRotation(NextFacingDirection));
        partent.rotation = Quaternion.Slerp(partent.rotation, rotation,  Time.deltaTime * soomth);
    }
}
