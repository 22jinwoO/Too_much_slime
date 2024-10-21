using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// 공통 로직을 담은 추상 클래스
public abstract class SkillCardBase : MonoBehaviour, ISkillCard
{
    #region ISkillCard 인터페이스 구현
    public PlayerUnitStats Player { get; set; }
    public Sprite AtrributeImg { get { return atrributeImgs[(int)Skill_Type]; } set { } }
    public Sprite SKillImg { get { return sKillImgs; } set { } }
    public int NeedJam { get { return needJamCnt[(int)Skill_Type]; } set { } }
    public string TitleValue { get { return titleValues[(int)Skill_Type]; } set { } }
    public int CardLevel { get => cardLevel; set => cardLevel = value; }
    public string SkillContentValue { get { return skillContentValues[(int)Skill_Type]; } set { } }

    #endregion

    public Sprite[] atrributeImgs;

    public Sprite sKillImgs;

    public SkillBase thisSkill;
    
    public int[] needJamCnt;


    protected string[] titleValues;

    protected string[] skillContentValues;

    protected int cardLevel;

    // 레벨업을 처리하는 Action
    public Func<bool> LevelUpAction;

    [field: SerializeField] public cardType Skill_Type { get; set; }


    private void Start()
    {
        cardLevel = 0;

        // 자식 클래스에서 스킬별로 구현할 초기화 메서드 호출
        InitializeValues();


        LevelUpAction = SkillCard_LevelUp;
    }

    public bool SkillCard_LevelUp()
    {
        if (PlayerJamManager.Instance.playerJamCnt < NeedJam) return false;

        PlayerJamManager.Instance.playerJamCnt -= NeedJam;
        PlayerJamManager.Instance.jamCntTxt.text = PlayerJamManager.Instance.playerJamCnt.ToString();

        ApplyLevelUp();

        return true;
    }

    //스킬 레벨업 효과를 정의하는 메서드
    protected void ApplyLevelUp()
    {
        cardLevel++;
        thisSkill.onSkillStat_LevelUp(Skill_Type, cardLevel);
    }

    // 자식 클래스에서 초기값 설정 메서드 구현
    protected abstract void InitializeValues();
}
