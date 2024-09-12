using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlime : MonsterUnitStats
{
    public override void InitData(int currentStage)
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        GetComponent<BoxCollider2D>().isTrigger = false;

        rigid.velocity = Vector2.zero;
        rigid.
        transform.rotation = Quaternion.Euler(Vector3.zero);

        maxHp = 500 * currentStage;
        curHp = maxHp;
        atkDmg = 5f * currentStage;
        atkSpd = 0.3f;
    }

    private void Awake()
    {
        InitData(1);
    }
}
