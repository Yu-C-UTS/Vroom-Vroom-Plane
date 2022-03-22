using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    public GameObject formation;
    public GameObject startPoint;

    [SerializeField]
    private DirectionsUtil.Direction startFacingDirection;
    private GameObject[] planes;


    void Awake()
    {
        spawn();
    }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0){
            Debug.Log("clear");
            spawn();
        }
    }

    private void spawn(){
        formation.GetComponent<MovementBehavior>().setFacingDirect(startFacingDirection);
        Instantiate(formation, startPoint.transform.position, Quaternion.Euler(0, 0, -135));
    }
}
