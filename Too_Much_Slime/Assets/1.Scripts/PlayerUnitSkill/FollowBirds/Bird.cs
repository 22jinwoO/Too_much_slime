using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public SkillBase followBird;

    public Projectile bullet;

    public float atkSpd;

    public void InitData()
    {
        // 총알 데미지
        bullet.attackDmg = followBird.skillDamage;

        //총알 이동 속도
        bullet.MoveSpeed = 500f;
    }

    public void MoveTo(Vector2 position)
    {
        transform.position = position;
    }

    private void Update()
    {
        if(followBird.skillAtkSpd > atkSpd) atkSpd += Time.deltaTime;

        else if(followBird.skillAtkSpd <= atkSpd)
        {
            atkSpd = 0f;
            GameObject prefab = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
            prefab.SetActive(true);
        }
    }
}
