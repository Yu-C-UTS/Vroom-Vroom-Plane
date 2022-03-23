using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_DoubleFireCount : PowerUpBase
{
    protected override void powerUpEffect()
    {
        GameManager.Instance.ActivePlayerUnit.PowerUpDoubleFire();
    }
}
