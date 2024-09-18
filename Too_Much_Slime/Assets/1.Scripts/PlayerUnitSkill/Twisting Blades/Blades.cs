using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blades : MonoBehaviour
{
    [SerializeField]private float attackDmg;
    
    public SkillBase twistingBlades;

    [SerializeField] private float rotateSpeed;

    private void Awake()
    {
        rotateSpeed = 30f;
    }
    public void InitData()
    {
        // 칼날 데미지
        attackDmg = twistingBlades.skillDamage;
    }
    private void Update()
    {
        // Z축을 기준으로 일정하게 회전시키기 (20도씩 회전)
        transform.Rotate(0, 0, 20f * Time.deltaTime * rotateSpeed);
    }
    public void MoveTo(Vector2 position)
    {
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PlayerBullet") && collision.gameObject.CompareTag("Monster"))
        {
            if (collision != null) collision.gameObject.GetComponent<UnitDamaged>().Damaged(attackDmg);
        }
    }
}
