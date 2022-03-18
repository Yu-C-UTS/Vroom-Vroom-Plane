using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputManager _instance;
    public InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private DirectionsUtil.Direction _currentMovementDirection;
    public DirectionsUtil.Direction CurrentMovementDirection
    {
        get
        {
            return _currentMovementDirection;
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
        _currentMovementDirection = DirectionsUtil.Direction.Forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
