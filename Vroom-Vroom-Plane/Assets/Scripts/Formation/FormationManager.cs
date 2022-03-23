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
        spawn(startFacingDirection, startPoint.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        if(formation.CompareTag("EnemyFormation") && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0){
            Debug.Log("Enemyclear");
            if(spawnedlimiter < 1){
                spawnedlimiter++;
                StartCoroutine(spawnFormation());
            }
        }
        
        if(formation.CompareTag("AllyFormation") && GameObject.FindGameObjectsWithTag("Ally").Length <= 0){
            Debug.Log("Allyclear");
            if(spawnedlimiter < 1){
                spawnedlimiter++;
                StartCoroutine(spawnFormation());
            }
            
        }
    }

    private void spawn(DirectionsUtil.Direction facingDirection, Vector3 startPosition){
        formation.GetComponent<MovementBehavior>().FacingDirection = facingDirection;
        Instantiate(formation, startPosition, Quaternion.Euler(0, 0, DirectionsUtil.DirectionToRotation(startFacingDirection)));
        spawnedlimiter = 0;
    }

    IEnumerator spawnFormation(){
        yield return new WaitForSeconds(2);
        spawn(startFacingDirection, startPoint.transform.position);
    }
}
