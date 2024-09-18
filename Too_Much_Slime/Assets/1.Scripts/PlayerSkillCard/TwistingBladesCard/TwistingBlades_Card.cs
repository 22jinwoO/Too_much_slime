using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwistingBlades_Card : MonoBehaviour, ISkillCard
{
    public PlayerUnitStats Player { get; set; }

    public Sprite[] atrributeImgs;

    public Sprite sKillImgs;
    public Sprite AtrributeImg { get => atrributeImgs[(int)Skill_Type]; set { } }
    public Sprite SKillImg { get => sKillImgs; set { } }
    public int NeedJam { get => needJamCnt[(int)Skill_Type]; set { } }

    private int cardLevel;

    public string[] titleValues;

    public string[] skillContentValues;

    public int[] needJamCnt;

    public string TitleValue
    {
        get => titleValues[(int)Skill_Type]; set { }
    }

    public string SkillContentValue
    {
        get => skillContentValues[(int)Skill_Type]; set { }
    }

    public int CardLevel { get => cardLevel; set => value = cardLevel; }

    [field: SerializeField]
    public cardType Skill_Type { get; set; }

    private void Awake()
    {
        titleValues = new string[3];

        skillContentValues = new string[3];

        needJamCnt = new int[3];

        cardLevel = 0;
        titleValues[0] = "불의 칼날 - 강력";
        titleValues[1] = "물의 칼날 - 냉기";
        titleValues[2] = "바람 칼날 - 속도";
        skillContentValues[0] = "회전 칼날 데미지 + 30%";
        skillContentValues[1] = "회전 칼날 갯수 + 1";
        skillContentValues[2] = "회전 칼날 회전 속도 + 30%";

        needJamCnt[0] = 6;
        needJamCnt[1] = 7;
        needJamCnt[2] = 8;

        print($"{gameObject.name}, {TitleValue}, {SkillContentValue}");
    }

    public void SkillCard_LevelUp()
    {
        if (PlayerJamManager.Instance.playerJamCnt < NeedJam) return;

        PlayerJamManager.Instance.playerJamCnt -= NeedJam;
        PlayerJamManager.Instance.jamCntTxt.text = PlayerJamManager.Instance.playerJamCnt.ToString();

        cardLevel++;

        Player.twistingBlades.SkillStat_LevelUp(Skill_Type, cardLevel);
    }
}
