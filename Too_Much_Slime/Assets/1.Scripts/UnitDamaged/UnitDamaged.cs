using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UnitDamaged : MonoBehaviour
{
    [SerializeField] BaseUnitStats stats;
    public Transform attacker;

    [SerializeField] private OnDeadEvent deadEvent;

    [SerializeField] private SpriteRenderer sprite;

    private void Awake()
    {
        stats = GetComponent<BaseUnitStats>();
        deadEvent = GetComponent<OnDeadEvent>();

        if(gameObject.CompareTag("Monster")) sprite =GetComponent<SpriteRenderer>();
    }

    public void Damaged(float atkDmg)
    {
        if (stats.curHp <= 0f) return;

        stats.curHp -= atkDmg;

        if (gameObject.CompareTag("Monster")) StartCoroutine(nameof(OnHit));

        if (gameObject.CompareTag("Monster") && stats.curHp <= 0)
        {
            if (attacker != null) attacker.GetComponent<PlayerAttack>().target = null;

            deadEvent.OnDead(stats, attacker);
        }
        
    }

    IEnumerator OnHit()
    {
        sprite.color = new Color(0.9f, 0.2f, 0.2f);

        yield return new WaitForSecondsRealtime(0.1f);

        sprite.color = new Color(1f, 1f, 1f);


    }
}
