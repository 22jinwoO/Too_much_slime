using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    [SerializeField]
    private PlayerUnitStats player;

    [SerializeField]
    private SkillBase[] playerSkills;

    public SkillCardBase[] skillCards;

    private void Awake()
    {
        playerSkills = player.GetComponents<SkillBase>();

        skillCards = GetComponentsInChildren<SkillCardBase>();

        for (int i = 0; i < playerSkills.Length; i++)
            playerSkills[i].player = player;

        for (int i = 0; i < skillCards.Length; i++)
            skillCards[i].Player = player;        
    }
}
