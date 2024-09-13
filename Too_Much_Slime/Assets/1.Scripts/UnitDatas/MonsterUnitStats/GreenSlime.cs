using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSlime : MonsterUnitStats
{
    private float standard_MaxHp;
    private float standard_atkDmg;
    public override void InitData(int currentStage)
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<BoxCollider2D>().isTrigger = false;

        rigid.velocity = Vector2.zero;
        rigid.
        transform.rotation = Quaternion.Euler(Vector3.zero);

        // 오브젝트 타입이 몬스터 일 경우 - 스테이지 단계 N 당 몬스터 공격력, 체력 N * 10%씩 강화
        maxHp = standard_MaxHp * (1 + currentStage * 0.1f);
        curHp = maxHp;
        atkDmg = standard_atkDmg * (1 + currentStage * 0.1f);
        atkSpd = 0.3f;
    }

    private void Awake()
    {
        standard_MaxHp = 100f;
        standard_atkDmg = 3f;
        maxHp = standard_MaxHp;
        atkDmg = standard_atkDmg;
        InitData(1);
    }
}
