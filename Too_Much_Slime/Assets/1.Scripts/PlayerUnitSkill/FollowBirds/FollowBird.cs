using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBird : SkillBase
{
    [SerializeField]
    private float distToAway;

    [SerializeField] private Bird birdPrefab;

    [SerializeField] List<Bird> birdList = new List<Bird>();

    private void Awake()
    {

        birdPrefab.followBird = this;
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

        birdList.Clear();

    }


    public override void SetSkill()
    {
        // 유닛 뒤로 가로로 정렬되는 코드
        float startX = player.transform.position.x - (birdList.Count - 1) * 0.5f * distToAway; // 시작 X 좌표 계산

        // Y 좌표를 target.position.y 기준으로 -2
        float y = player.transform.position.y - 0.5f; 

        for (int i = 0; i < birdList.Count; ++i)
        {
            birdList[i].transform.SetParent(player.birdsParent);
            float x = startX + i * distToAway; // 각 유닛의 X 좌표 계산
            birdList[i].MoveTo(new Vector3(x, y, 0)); // Z축은 2D이므로 0으로 설정
        }
    }

    public override void SkillStat_LevelUp(cardType type, int cardLevel)
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
                case cardType.Fire:
                    skillDamage = skillDamage + skillDamage * 0.3f;
                    for (int i = 0; i < cardLevel; ++i)
                    {
                        birdPrefab.InitData();
                    }
                    break;

            case cardType.Ice:

                    birdList.Add(Instantiate(birdPrefab));
                    SetSkill();
                    for (int i = 0; i < cardLevel; ++i)
                    {
                        birdPrefab.InitData();
                    }
                    break;

                case cardType.Ground:
                    
                    break;

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
