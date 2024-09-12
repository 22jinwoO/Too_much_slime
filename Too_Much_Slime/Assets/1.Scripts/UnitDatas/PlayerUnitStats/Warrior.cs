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
        atkSpd = 0.8f;
        moveSpeed = 100f;
    }

    private void Awake()
    {
        InitData();
        twistingBlades = GetComponent<TwistingBlades>();
        followeBirds = GetComponent<FollowBird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Skill_Item"))
        {
            collision.gameObject.GetComponent<ISkillCard>().SkillCard_LevelUp();
        }

    }
}
