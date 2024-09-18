using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GreenSlimeKing : MonsterUnitStats
{
    private float standard_MaxHp;
    private float standard_atkDmg;

    [SerializeField] private Image hpBar;
    [SerializeField] private TextMeshProUGUI hpTxt;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();
        monsterAttack = GetComponent<MonsterAttack>();
        unitDamaged = GetComponent<UnitDamaged>();

        standard_MaxHp = 3000f;
        standard_atkDmg = 15f;
        maxHp = standard_MaxHp;
        atkDmg = standard_atkDmg;
        InitData(StageManager.Instance.stageNum);
    }

    private void Update()
    {
        hpBar.fillAmount = curHp / maxHp;
        hpTxt.text = Mathf.RoundToInt(curHp).ToString();

    }
    public override void InitData(int currentStage)
    {
        monsterAttack.target = null;

        rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        boxCol.isTrigger = false;

        rigid.velocity = Vector2.zero;

        spr.color = new Color(1f, 1f, 1f);
        transform.rotation = Quaternion.Euler(Vector3.zero);

        // 보스 몬스터 일 경우 - 스테이지 단계 N 당 몬스터 공격력, 체력 N * 10%씩 강화
        maxHp = standard_MaxHp * (1 + currentStage * 0.1f);
        curHp = maxHp;
        atkDmg = standard_atkDmg * (1 + currentStage * 0.1f);
        atkSpd = 1.5f;
    }

}
