using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    public GameObject formation;
    public GameObject startPoint;
    public float DircChangeGap;

    [SerializeField]
    private DirectionsUtil.Direction startFacingDirection;

    private float DircChangeTimer;

    void Awake()
    {
        formation.GetComponent<MovementBehavior>().setFacingDirect(startFacingDirection);
        spawn();
    }
    void Start(){
        DircChangeTimer = DircChangeGap;
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void spawn(){
        Instantiate(formation, startPoint.transform.position, Quaternion.Euler(0, 0, -135));
    }
}
