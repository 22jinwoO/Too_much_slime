using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlime : MonsterUnitStats
{
    public override void InitData(int currentStage)
    {
        maxHp = 500;
        curHp = maxHp;
        atkDmg = 5f;
        atkSpd = 0.3f;
    }

    private void Awake()
    {
        InitData(1);
    }
}
