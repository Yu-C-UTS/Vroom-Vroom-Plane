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
        if(formation.CompareTag("EnemyFormation") && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0){
            Debug.Log("Enemyclear");
            if(spawnedlimiter < 1){
                spawnedlimiter++;
                Invoke("spawn", 1.0f);
            }
        }
        
        if(formation.CompareTag("AllyFormation") && GameObject.FindGameObjectsWithTag("Ally").Length <= 0){
            Debug.Log("Allyclear");
            if(spawnedlimiter < 1){
                spawnedlimiter++;
                Invoke("spawn", 1.0f);
            }
            
        }
    }

    private void spawn(){
        formation.GetComponent<MovementBehavior>().setFacingDirect(startFacingDirection);
        Instantiate(formation, startPoint.transform.position, Quaternion.Euler(0, 0, -135));
        spawnedlimiter = 0;
    }
}
