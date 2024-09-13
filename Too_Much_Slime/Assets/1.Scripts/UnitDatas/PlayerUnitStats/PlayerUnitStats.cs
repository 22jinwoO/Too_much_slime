using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUnitStats : BaseUnitStats
{   
    //플레이어 최고 높이값
    private float maxY
    {
        get 
        {
            if (transform.position.y < 0f) return 0f;
            if (transform.position.y > 250f) return 250f;
            return (transform.position.y); 
        }
    } 

    // 읽기 전용으로만 쓸 때, 이 값을 불러와도 값에 변화를 주지 못하게 읽기로만 
    public float MaxY
    { get { return maxY; } }

    public float plusAtkDmg;

    public float plusAtkSpd;

    public float plusMaxHp;

    public float moveSpeed;

    public Transform bladesParent;
    public Transform birdsParent;

    public SkillBase twistingBlades;
    public SkillBase followeBirds;

    public abstract void InitData();
}
