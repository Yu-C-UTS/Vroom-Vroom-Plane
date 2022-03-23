using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormationController : FormationController
{
    [SerializeField]
    private UnitBase bossUnitPrefab;

    protected override void respawnFormation()
    {
        for (int i = 0; i < formationSize; i++)
        {
            if(formationUnits[i] == null)
            {
                if(GameManager.Instance.EnemyDestroyCount <= 0)
                {
                    formationUnits[i] = Instantiate(bossUnitPrefab, transform.TransformPoint(new Vector3( (i * formationUnitSeparation) - ((formationSize - 1) * formationUnitSeparation / 2), 0, 0)), Quaternion.identity, transform);
                }
                else
                {
                    formationUnits[i] = Instantiate(respawnFormationUnitPrefab, transform.TransformPoint(new Vector3( (i * formationUnitSeparation) - ((formationSize - 1) * formationUnitSeparation / 2), 0, 0)), Quaternion.identity, transform);
                }
            }
        }
    }
}
