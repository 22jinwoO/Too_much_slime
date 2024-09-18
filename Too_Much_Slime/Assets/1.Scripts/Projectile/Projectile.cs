using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float attackDmg;
    public float MoveSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rigid.AddForce(transform.up * MoveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        if(gameObject.CompareTag("PlayerBullet")) rigid.velocity = Vector2.up * MoveSpeed * Time.deltaTime;
        if(gameObject.CompareTag("MonsterBullet")) rigid.velocity = Vector2.down * MoveSpeed * Time.deltaTime;

        //Debug.LogWarning(rigid.velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PlayerBullet") && collision.gameObject.CompareTag("Monster"))
        {
            if(collision!=null) collision.gameObject.GetComponent<UnitDamaged>().Damaged(attackDmg);

            Destroy(gameObject);
        }

        if (gameObject.CompareTag("MonsterBullet") && collision.gameObject.CompareTag("Player"))
        {
            if (collision != null) collision.gameObject.GetComponent<UnitDamaged>().Damaged(attackDmg);

            Destroy(gameObject);
        }

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (gameObject.CompareTag("PlayerBullet") && collision.gameObject.CompareTag("Monster")) collision.gameObject.GetComponent<UnitDamaged>().Damaged(attackDmg);

    //}
}
