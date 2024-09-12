using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterUnitStats : BaseUnitStats
{
    protected float dropValue;

    public abstract void InitData(int currentStage);
}
