using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Warrior : PlayerUnitStats
{
    [SerializeField] private ShopManager shopManager;

    [SerializeField] private Image hpBar;
    [SerializeField] private TextMeshProUGUI hpTxt;

    public override void InitData()
    {
        transform.position = new Vector3(0, -5f, 0);
        maxHp = 500;
        curHp = maxHp;
        atkDmg = 80f;
        atkSpd = 0.8f;
        moveSpeed = 150f;

        anim.SetBool(hashDead, false);

        twistingBlades.InitData();
        followeBirds.InitData();
    }

    private void Awake()
    {
        twistingBlades = GetComponent<TwistingBlades>();
        followeBirds = GetComponent<FollowBird>();

        InitData();

    }

    private void Update()
    {
        hpBar.fillAmount = curHp / maxHp;
        hpTxt.text = Mathf.RoundToInt(curHp).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Jam":
                int jamCnt = 1;
                PlayerJamManager.Instance.GetJam(jamCnt);
                Destroy(collision.gameObject);
                break;

            case "Skill_Item":
                collision.gameObject.GetComponent<ISkillCard>().SkillCard_LevelUp();
                break;

            case "JamShop":
                Destroy(collision.gameObject);
                shopManager.ShopOpen();
                break;

            case "3Jams":
                int jamsCnt = 3;
                PlayerJamManager.Instance.GetJam(jamsCnt);
                Destroy(collision.gameObject);
                break;
        }
    }
}
