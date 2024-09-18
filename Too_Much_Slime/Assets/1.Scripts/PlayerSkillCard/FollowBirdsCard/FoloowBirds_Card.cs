using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoloowBirds_Card : MonoBehaviour,ISkillCard
{
    public PlayerUnitStats Player { get; set; }

    private int cardLevel;
    
    public string[] titleValues;

    public string[] skillContentValues;

    public Sprite[] atrributeImgs;

    public Sprite sKillImgs;
    public Sprite AtrributeImg { get => atrributeImgs[(int)Skill_Type]; set { } }
    public Sprite SKillImg { get => sKillImgs; set { } }
    public int NeedJam { get => needJamCnt[(int)Skill_Type]; set { } }


    public string TitleValue
    {
        get => titleValues[(int)Skill_Type]; set { }
    }

    public string SkillContentValue
    {
        get => skillContentValues[(int)Skill_Type]; set { }
    }

    public int[] needJamCnt;
    public int CardLevel { get => cardLevel; set => value = cardLevel; }

    [field : SerializeField]
    public cardType Skill_Type { get; set; }

    private void Awake()
    {
        titleValues = new string[3];

        skillContentValues = new string[3];

        needJamCnt = new int[3];

        cardLevel = 0;
        titleValues[0] = "불의 새 -강력";
        titleValues[1] = "물의 새 -냉기";
        titleValues[2] = "바람 새 -속도";
        skillContentValues[0] = "새 데미지 +30 %";
        skillContentValues[1] = "새 마리수 +1";
        skillContentValues[2] = "새 발사체 속도 + 30 %";

        print($"{gameObject.name}, {TitleValue}, {SkillContentValue}");

        needJamCnt[0] = 6;
        needJamCnt[1] = 7;
        needJamCnt[2] = 8;
    }

    public void SkillCard_LevelUp()
    {
        if (PlayerJamManager.Instance.playerJamCnt < NeedJam) return;

        PlayerJamManager.Instance.playerJamCnt -= NeedJam;
        PlayerJamManager.Instance.jamCntTxt.text = PlayerJamManager.Instance.playerJamCnt.ToString();
        cardLevel++;

        Player.followeBirds.SkillStat_LevelUp(Skill_Type, cardLevel);
    }
}
