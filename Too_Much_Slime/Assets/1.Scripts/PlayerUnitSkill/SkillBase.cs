using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SkillBase : MonoBehaviour
{
    public PlayerUnitStats player;

    [SerializeField] protected GameObject vfx;

    public int skillLevel;

    public float skillDamage;

    public float skillAtkSpd;

    public float skillMoveSpeed;

    public abstract void SetSkill();
    public abstract void SkillStat_LevelUp(cardType type, int cardLevel);
}
