using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowBirds_Card : SkillCardBase
{
    protected override void InitializeValues()
    {
        thisSkill = Player.GetComponent<FollowBird>();

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

        needJamCnt[0] = 6;
        needJamCnt[1] = 7;
        needJamCnt[2] = 8;
    }
}
