using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillCard
{
    public PlayerUnitStats Player { get; set; }
    public cardType Skill_Type { get; set; }

    public int CardLevel{ get; set;}

    public void SkillCard_LevelUp();
}
