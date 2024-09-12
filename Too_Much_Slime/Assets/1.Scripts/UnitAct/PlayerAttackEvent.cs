using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttackEvent : MonoBehaviour
{
    [Header("공격 이펙트")]
    [SerializeField] private GameObject atkVfx;

    [SerializeField] private PlayerAttack attack;

    private void Awake()
    {
        attack = GetComponentInParent<PlayerAttack>();
    }


    // 애니메이션 이벤트에서 호출할 함수
    public void OnAttackEvent()
    {
        attack.OnAttack();
    }
}
