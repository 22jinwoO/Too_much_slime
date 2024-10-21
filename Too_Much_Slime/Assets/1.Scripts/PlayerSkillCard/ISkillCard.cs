using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ISkillCard
{
    public Sprite AtrributeImg { get; set; }
    public Sprite SKillImg { get; set; }
    public PlayerUnitStats Player { get; set; }
    public cardType Skill_Type { get; set; }
    public string TitleValue { get; set; }

    public string SkillContentValue { get; set; }

    public int CardLevel{ get; set;}
    public int NeedJam { get; set;}
}
