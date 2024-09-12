using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterUnitStats : BaseUnitStats
{
    public IMonsterFactory MonsterFactory;

    protected float dropValue;

    public abstract void InitData(int currentStage);
}
