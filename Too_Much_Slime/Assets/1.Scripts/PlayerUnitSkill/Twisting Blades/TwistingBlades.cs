using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistingBlades: SkillBase
{
    [SerializeField]
    private float distToAway;

    [SerializeField] private Blades bladePrefab;

    [SerializeField] List<Blades> bladeList = new List<Blades>();
    private void Awake()
    {

        InitData();
        bladePrefab.twistingBlades = this;

        onSkillStat_LevelUp = SkillStat_LevelUp;
    }
    private void Update()
    {
        player.bladesParent.transform.position = player.transform.position + new Vector3(0f,0.3f,0f);
        if (bladeList.Count != 0)
        {
            orbitAround();
        }
    }
    //
    void orbitAround()
    {
        player.bladesParent.RotateAround(transform.position, Vector3.back, skillMoveSpeed * Time.deltaTime);
    }
    public override void InitData()
    {
        skillLevel = 0;
        distToAway = 1f;

        skillDamage = 50;

        skillAtkSpd = 3f;

        skillMoveSpeed = 100f;

        for (int i = 0; i < bladeList.Count; ++i)
        {
            Destroy(bladeList[i].gameObject);
        }
        bladeList.Clear();
    }

    protected override void SetSkill()
    {
        for (int i = 0; i < bladeList.Count; ++i)
        {
            bladeList[i].transform.SetParent(player.bladesParent);

            float angle = 360 * i / bladeList.Count;
            angle = Mathf.PI * angle / 180;
            float x = player.transform.position.x + Mathf.Cos(angle) * distToAway;
            float y = player.transform.position.y + Mathf.Sin(angle) * distToAway;
            bladeList[i].MoveTo(new Vector3(x, y, 1));
        }
    }

    protected override void SkillStat_LevelUp(cardType type, int cardLevel)
    {
        skillLevel++;

        if (skillLevel == 1)
        {
            bladeList.Add(Instantiate(bladePrefab));
            SetSkill();
        }

        Mathf.Clamp(skillLevel, 0, 4);

        switch (type)
        {
            case cardType.Fire:
                skillDamage = skillDamage + skillDamage * 0.3f;
                for (int i = 0; i < cardLevel; ++i)
                {
                    bladePrefab.InitData();
                }
                break;

            case cardType.Ice:

                bladeList.Add(Instantiate(bladePrefab));
                SetSkill();
                for (int i = 0; i < cardLevel; ++i)
                {
                   bladePrefab.InitData();
                }
                break;

            case cardType.Ground:

                break;

            case cardType.Wind:
                skillMoveSpeed = skillMoveSpeed + skillMoveSpeed * 0.3f;
                for (int i = 0; i < cardLevel; ++i)
                {
                    bladePrefab.InitData();
                }
                break;
        }


    }


}
