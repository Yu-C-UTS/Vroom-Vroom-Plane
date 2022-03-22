using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimUpdater : MonoBehaviour
{
    [SerializeField]
    private InputManager inputmanager;
    private float soomth = 5.0f;
    private Quaternion rotation = Quaternion.Euler(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        updateAnim(inputmanager);
    }

    private void updateAnim(InputManager input){
        rotation = Quaternion.Euler(0, 0, DirectionsUtil.DirectionToRotation(input.CurrentMovementDirection));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,  Time.deltaTime * soomth);
    }
}
