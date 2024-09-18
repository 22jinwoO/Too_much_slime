using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterUnitStats : BaseUnitStats
{
    public IMonsterFactory MonsterFactory;

    public Rigidbody2D rigid;
    public SpriteRenderer spr;
    public BoxCollider2D boxCol;
    public MonsterAttack monsterAttack;
    public UnitDamaged unitDamaged;

    protected float dropValue;

    public void UnitDead()
    {
        gameObject.SetActive(false);
        MonsterFactory.factory_ObjPool.Monsters.Enqueue(this);
    }
    public abstract void InitData(int currentStage);
}
