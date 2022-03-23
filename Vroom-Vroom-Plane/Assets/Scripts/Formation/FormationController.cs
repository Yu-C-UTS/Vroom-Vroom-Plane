using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBehavior))]
public class FormationController : MonoBehaviour
{
    private MovementBehavior movementBehavior;
    
    [SerializeField]
    public Transform partent;
    [SerializeField]
    private float MinTurnDelay = 2f;
    [SerializeField]
    private float MaxTurnDelay = 5f;
    private float TurnTimer;
    private float soomth = 1.0f;
    private DirectionsUtil.Direction NextFacingDirection;


    [SerializeField]
    protected UnitBase respawnFormationUnitPrefab;
    [SerializeField]
    protected float formationUnitSeparation;
    [SerializeField]
    protected int formationSize;
    protected UnitBase[] formationUnits;

    const float formationRespawnViewDelay = 3f;
    private float formationRespawnCooldown = 0;

    private void Awake() 
    {
        movementBehavior = GetComponent<MovementBehavior>();
        if(movementBehavior == null)
        {
            Debug.LogError("No Movement Behavior found");
        }    
    }

    private void Start() 
    {
        formationUnits = new UnitBase[formationSize];
        respawnFormation();

        ResetTurnTimer();
        NextFacingDirection = movementBehavior.FacingDirection;
    }

    private void Update() 
    {
        TurnUpdate();
        UpdateFormation();

        if(isAnyFormationUnitVisible() == false)
        {
            formationRespawnCooldown -= Time.deltaTime;
            if(formationRespawnCooldown < 0)
            {
                respawnFormation();
                repositionFormation();
                formationRespawnCooldown = formationRespawnViewDelay;
            }
        }
        else
        {
            formationRespawnCooldown = formationRespawnViewDelay;
        }
    }

    private void TurnUpdate()
    {
        TurnTimer -= Time.deltaTime;

        if(TurnTimer <= 0)
        {
            Turn();
        }
    }

    private void ResetTurnTimer()
    {
        TurnTimer = Random.Range(MinTurnDelay, MaxTurnDelay);
    }

    private void Turn()
    {
        int turnDirection = Random.Range(0, 2);
        if(turnDirection == 0)
        {
            TurnLeft();
            Quaternion rotation = Quaternion.Euler(transform.root.rotation.x, transform.root.rotation.y, transform.root.rotation.z + 45);
            transform.root.rotation = Quaternion.Slerp(transform.root.rotation, rotation,  Time.deltaTime * soomth);
        }
        else
        {
            TurnRight();
            Quaternion rotation = Quaternion.Euler(transform.root.rotation.x, transform.root.rotation.y, transform.root.rotation.z - 45);
            transform.root.rotation = Quaternion.Slerp(transform.root.rotation, rotation,  Time.deltaTime * soomth);
        }

        ResetTurnTimer();
    }

    private void TurnLeft()
    {
        movementBehavior.FacingDirection = (DirectionsUtil.Direction)(((int)movementBehavior.FacingDirection - 1 + 8)%8);
    }

    private void TurnRight()
    {
        movementBehavior.FacingDirection = (DirectionsUtil.Direction)(((int)movementBehavior.FacingDirection + 1 + 8)%8);
    }

    private void UpdateFormation(){
        NextFacingDirection = movementBehavior.FacingDirection;
        Quaternion rotation = Quaternion.Euler(partent.rotation.x, partent.rotation.y, DirectionsUtil.DirectionToRotation(NextFacingDirection));
        partent.rotation = Quaternion.Slerp(partent.rotation, rotation,  Time.deltaTime * soomth);
    }

    private bool isAnyFormationUnitVisible()
    {
        foreach (UnitBase unit in formationUnits)
        {
            if(unit.IsVisible)
            {
                return true;
            }
        }
        return false;
    }

    private void repositionFormation()
    {
        switch (NextFacingDirection)
        {
            case DirectionsUtil.Direction.Forward:
                transform.position = new Vector3(0, -GameManager.Instance.VerticalSpawnEdge, 0);
                break;

            case DirectionsUtil.Direction.ForwardRight:
                transform.position = new Vector3(-GameManager.Instance.HorizontalSpawnEdge, -GameManager.Instance.VerticalSpawnEdge, 0);
                break;

            case DirectionsUtil.Direction.Right:
                transform.position = new Vector3(-GameManager.Instance.HorizontalSpawnEdge, 0, 0);
                break;

            case DirectionsUtil.Direction.BackwardsRight:
                transform.position = new Vector3(-GameManager.Instance.HorizontalSpawnEdge, GameManager.Instance.VerticalSpawnEdge, 0);
                break;

            case DirectionsUtil.Direction.Backwards:
                transform.position = new Vector3(0, GameManager.Instance.VerticalSpawnEdge, 0);
                break;

            case DirectionsUtil.Direction.BackwardsLeft:
                transform.position = new Vector3(GameManager.Instance.HorizontalSpawnEdge, GameManager.Instance.VerticalSpawnEdge, 0);
                break;

            case DirectionsUtil.Direction.Left:
                transform.position = new Vector3(GameManager.Instance.HorizontalSpawnEdge, 0, 0);
                break;

            case DirectionsUtil.Direction.ForwardLeft:
                transform.position = new Vector3(GameManager.Instance.HorizontalSpawnEdge, -GameManager.Instance.VerticalSpawnEdge, 0);
                break;

            default:
                transform.position = Vector3.zero;
                break;
        }
    }

    protected virtual void respawnFormation()
    {
        for (int i = 0; i < formationSize; i++)
        {
            if(formationUnits[i] == null)
            {
                formationUnits[i] = Instantiate(respawnFormationUnitPrefab, transform.TransformPoint(new Vector3( (i * formationUnitSeparation) - ((formationSize - 1) * formationUnitSeparation / 2), 0, 0)), Quaternion.identity, transform);
            }
        }
    }
}
