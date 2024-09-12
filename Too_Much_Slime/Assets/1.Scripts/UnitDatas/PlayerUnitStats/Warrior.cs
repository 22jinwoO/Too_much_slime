using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerUnitStats
{
    public override void InitData()
    {
        maxHp = 500;
        curHp = maxHp;
        atkDmg = 5f;
        atkSpd = 0.3f;
    }
}
