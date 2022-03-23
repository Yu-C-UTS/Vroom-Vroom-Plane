using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    public GameObject formation;
    public GameObject startPoint;

    [SerializeField]
    private DirectionsUtil.Direction startFacingDirection;
    private int spawnedlimiter = 0;



    void Awake()
    {
        spawn();
    }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0){
            Debug.Log("clear");
            if(spawnedlimiter < 1){
                spawnedlimiter++;
                Invoke("spawn", 1.0f);
            }
            
        }
    }

    private void spawn(){
        formation.GetComponent<MovementBehavior>().FacingDirection = startFacingDirection;
        Instantiate(formation, startPoint.transform.position, Quaternion.Euler(0, 0, DirectionsUtil.DirectionToRotation(startFacingDirection)));
        spawnedlimiter = 0;
    }
}
