using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUnitStats : BaseUnitStats
{
    public float plusAtkDmg;

    public float plusAtkSpd;

    public float plusMaxHp;

    public abstract void InitData();
}
