using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeadEvent : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameManager gameManager;

    private readonly int hashDead = Animator.StringToHash("isDead");

    public void OnDead(BaseUnitStats monster, Transform attacker)
    {
        transform.GetComponent<BoxCollider2D>().isTrigger = true;

        // 현재 회전 값을 Euler angles로 가져오기
        Vector3 currentRotation = transform.rotation.eulerAngles;

        //Z축 회전 값을 - 30f ~30f 사이의 랜덤한 값으로 설정
        float randomZRotation = Random.Range(-60f, 60f);

        // 새로운 Z축 값을 적용한 Quaternion으로 설정
        transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, randomZRotation);

        Rigidbody2D rigid = transform.GetComponent<Rigidbody2D>();

        rigid.constraints = RigidbodyConstraints2D.None;

        rigid.gravityScale = 2f;

        // 힘을 줌 (임펄스 모드)
        rigid.AddForce(2500f * transform.up * Time.deltaTime, ForceMode2D.Impulse);
    }

    public void OnDead()
    {
        anim.SetBool(hashDead, true);

        StartCoroutine(gameManager.GameEnd());

    }
}
