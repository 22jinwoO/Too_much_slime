using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBird : SkillBase
{
    // 오브젝트 간의 거리
    [SerializeField] private float distToAway;

    // 새 유닛 프리팹
    [SerializeField] private Bird birdPrefab;

    // 추가된 새 유닛들의 리스트
    [SerializeField] List<Bird> birdList = new List<Bird>();

    private void Awake()
    {
        birdPrefab.followBird = this; 

        //Action 연결
        onSkillStat_LevelUp = SkillStat_LevelUp;
    }

    public override void InitData()
    {
        distToAway = 0.5f;

        skillDamage = 50;

        skillAtkSpd = 3f;

        skillMoveSpeed = 500f;

        for (int i = 0; i < birdList.Count; ++i)
        {
            Destroy(birdList[i].gameObject);
        }

        // 리스트 초기화
        birdList.Clear();
    }


    protected override void SetSkill()
    {
        // 유닛 뒤로 가로로 정렬되는 코드, 시작 X 좌표 계산
        float startX = player.transform.position.x - (birdList.Count - 1) * 0.5f * distToAway; // 

        // Y 좌표를 target.position.y 기준으로 -0.5ㄹ
        float y = player.transform.position.y - 0.5f; 

        for (int i = 0; i < birdList.Count; ++i)
        {
            birdList[i].transform.SetParent(player.birdsParent);

            // 각 유닛의 X 좌표 계산
            float x = startX + i * distToAway;

            // Z축은 2D이므로 0으로 설정
            birdList[i].MoveTo(new Vector3(x, y, 0)); 
        }
    }

    protected override void SkillStat_LevelUp(cardType type, int cardLevel)
    {
        skillLevel++;

        if (skillLevel == 1)
        {
            birdList.Add(Instantiate(birdPrefab));
            SetSkill();
        }

        Mathf.Clamp(skillLevel, 0, 4);

        switch (type)
        {
            // 불속성 카드
            case cardType.Fire:
                skillDamage = skillDamage + skillDamage * 0.3f;
                for (int i = 0; i < cardLevel; ++i)
                {
                    birdPrefab.InitData();
                }
                break;

            // 냉기 속성 카드
            case cardType.Ice:
                birdList.Add(Instantiate(birdPrefab));
                SetSkill();
                for (int i = 0; i < cardLevel; ++i)
                {
                    birdPrefab.InitData();
                }
                break;

            // 대지 속성 카드
            case cardType.Ground:

                break;

            // 바람 속성 카드
            case cardType.Wind:
                skillAtkSpd = skillAtkSpd - skillAtkSpd * 0.3f;
                for (int i = 0; i < cardLevel; ++i)
                {
                    birdPrefab.InitData();
                }
                break;
        }


    }
}
