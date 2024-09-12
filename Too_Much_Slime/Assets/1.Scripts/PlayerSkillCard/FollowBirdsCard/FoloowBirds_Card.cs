using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoloowBirds_Card : MonoBehaviour,ISkillCard
{
    public PlayerUnitStats Player { get; set; }

    private int cardLevel;

    public int CardLevel { get => cardLevel; set => value = cardLevel; }

    [field : SerializeField]
    public cardType Skill_Type { get; set; }

    private void Awake()
    {
        cardLevel = 0;
    }

    public void SkillCard_LevelUp()
    {
        cardLevel++;

        Player.followeBirds.SkillStat_LevelUp(Skill_Type, cardLevel);
    }
}
