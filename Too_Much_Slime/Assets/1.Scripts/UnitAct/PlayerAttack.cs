using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private BaseUnitStats stats;
    public UnitDamaged target;

    [SerializeField] private float curAtkSpd;

    // 공격 데미지
    private float attackDamage;

    [SerializeField] private Animator anim;

    private readonly int hashAttack = Animator.StringToHash("isAttack");

    [SerializeField] private bool canAtk;
    private void Awake()
    {
        stats = GetComponent<BaseUnitStats>();
        attackDamage = stats.atkDmg;
    }

    void Update()
    {
        if (curAtkSpd < stats.atkSpd)
        {
            anim.SetBool(hashAttack, false);
            curAtkSpd += Time.deltaTime;
        }

        else canAtk = true;

        if(!canAtk) anim.SetBool(hashAttack, false);

        if(target != null && canAtk) anim.SetBool(hashAttack, true);
    }
    
    public void OnAttack()
    {
        target.attacker = transform;

        target?.Damaged(attackDamage);
        
        curAtkSpd = 0f;

        canAtk = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Monster"))
        {
            if (target == null) target = collision.transform.GetComponent<UnitDamaged>();
        }
    }
}
