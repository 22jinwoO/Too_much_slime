using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitDamaged : MonoBehaviour
{
    [SerializeField] BaseUnitStats stats;
    public Transform attacker;

    [SerializeField] private OnDeadEvent deadEvent;
    private void Awake()
    {
        stats = GetComponent<BaseUnitStats>();
        deadEvent = GetComponent<OnDeadEvent>();
    }

    public void Damaged(float atkDmg)
    {
        stats.curHp -= atkDmg;

        if (gameObject.CompareTag("Monster") && stats.curHp <= 0)
        {
            deadEvent.OnDead(stats, attacker);
            attacker.GetComponent<PlayerAttack>().target = null;
        }
        
    }
}
