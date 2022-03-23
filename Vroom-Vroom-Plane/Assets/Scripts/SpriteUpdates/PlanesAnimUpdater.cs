using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanesAnimUpdater : MonoBehaviour
{
    private float soomth = 5.0f;
    private Quaternion rotation = Quaternion.Euler(0, 0, 0);
    void Update()
    {
        updateAnim(gameObject.GetComponentInParent<MovementBehavior>().FacingDirection);
        //Debug.Log(gameObject.GetComponentInParent<MovementBehavior>().FacingDirection);
    }

    private void updateAnim(DirectionsUtil.Direction facingDirection){
        rotation = Quaternion.Euler(0, 0, DirectionsUtil.DirectionToRotation(facingDirection));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,  Time.deltaTime * soomth);
    }
}
