using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private BaseUnitStats stats;

    public UnitDamaged target;

    [SerializeField] private float curAtkSpd;

    // 공격 데미지
    [SerializeField] private float attackDamage;

    [SerializeField] private bool canAtk;

    private void Awake()
    {
        stats = GetComponent<BaseUnitStats>();

    }
    private void Start()
    {
        attackDamage = stats.atkDmg;
    }
    void Update()
    {
        if (curAtkSpd < stats.atkSpd) curAtkSpd += Time.deltaTime;

        else canAtk = true;

        if (target != null && canAtk) OnAttack();

    }

    public void OnAttack()
    {
        target.Damaged(attackDamage);

        curAtkSpd = 0f;

        canAtk = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (target == null) target = collision.transform.GetComponent<UnitDamaged>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) target = null;
    }

}
