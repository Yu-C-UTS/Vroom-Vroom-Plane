using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private DirectionsUtil.Direction _currentMovementDirection = DirectionsUtil.Direction.Forward;
    public DirectionsUtil.Direction CurrentMovementDirection
    {
        get
        {
            return _currentMovementDirection;
        }
    }
    public Vector2 CurrentMovementV2
    {
        get
        {
            return DirectionsUtil.DirectionToVector2(_currentMovementDirection);
        }
    }
    public Vector3 CurrentMovementV3
    {
        get
        {
            return DirectionsUtil.V2toV3YZSwap(CurrentMovementV2);
        }
    }

    void Awake() 
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }    

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _currentMovementDirection = updateInputDirection();
    }

    private DirectionsUtil.Direction updateInputDirection()
    {
        Vector2 inputVector = new Vector2();

        if(Input.GetKey(KeyCode.UpArrow))
        {
            inputVector += Vector2.up;
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            inputVector += Vector2.left;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            inputVector += Vector2.right;
        }

        if(Mathf.Approximately(inputVector.sqrMagnitude,0))
        {
            return _currentMovementDirection;
        }

        inputVector.Normalize();

        return DirectionsUtil.Vector2ToDirection(inputVector);
    }
}
