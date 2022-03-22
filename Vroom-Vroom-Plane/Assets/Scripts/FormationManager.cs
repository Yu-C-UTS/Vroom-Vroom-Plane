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

    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(formation, startPoint.transform.position, Quaternion.Euler(0, 0, -135));
        formation.GetComponent<MovementBehavior>().setFacingDirect(startFacingDirection);
        DircChangeTimer = DircChangeGap;
    }
    // Update is called once per frame
    void Update()
    {
        if(DircChangeTimer > 0){
            DircChangeTimer -= Time.deltaTime;
        }

        if(DircChangeTimer <= 0){
            formation.GetComponent<MovementBehavior>().setFacingDirect(newDirection());
            DircChangeTimer = DircChangeGap;
        }
    }

    private DirectionsUtil.Direction newDirection(){
        return (DirectionsUtil.Direction)Random.Range(0, 6);
    }
}
