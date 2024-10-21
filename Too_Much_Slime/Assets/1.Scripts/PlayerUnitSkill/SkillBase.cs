using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SkillBase : MonoBehaviour
{
    // 플레이어 오브젝트
    public PlayerUnitStats player;

    // 이펙트 오브젝트
    [SerializeField] protected GameObject vfx;

    public int skillLevel;

    public float skillDamage;

    public float skillAtkSpd;

    public float skillMoveSpeed;

    // 스킬 레벨업시 호출되는 Action
    public Action<cardType, int> onSkillStat_LevelUp;

    public abstract void InitData();
    protected abstract void SetSkill();
    protected abstract void SkillStat_LevelUp(cardType type, int cardLevel);
}
