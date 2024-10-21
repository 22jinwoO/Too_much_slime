using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwistingBlades_Card : SkillCardBase
{
    protected override void InitializeValues()
    {
        thisSkill = Player.GetComponent<TwistingBlades>();

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
}
