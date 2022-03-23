using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBehavior))]
public class PowerUpBase : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        UnitBase CollidedUnit = other.gameObject.GetComponent<UnitBase>();

        //Collided with something that is not a unit(plane), ignoring collision
        if(CollidedUnit == null)
        {
            return;
        }

        powerUpEffect();
    }

    protected virtual void powerUpEffect()
    {
        Debug.LogWarning("No Effect");
    }
}
