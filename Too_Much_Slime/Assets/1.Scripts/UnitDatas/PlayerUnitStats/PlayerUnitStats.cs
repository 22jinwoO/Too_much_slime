using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUnitStats : BaseUnitStats
{   
    //플레이어 최고 높이값
    private float maxY
    {
        get 
        {
            int playerArrivePoint = StageManager.Instance.stageNum - 1;

            // 플레이어가 도착지점을 지나 쳤을 때
            if (playerArrivePoint * 1000 + transform.position.y * 10f > StageManager.Instance.stageNum * 1000) return StageManager.Instance.stageNum * 1000;

            // 플레이어가 첫 스테이지를 시작하고 스타트 포인트를 안지나쳤을 때
            if (transform.position.y < 0f && StageManager.Instance.stageNum == 1) return 0f;

            // 플레이어가 첫 스테이지를 시작하고 스타트 포인트를 지나쳤을 때
            if (StageManager.Instance.stageNum == 1) return transform.position.y * 10f;

            // 플레이어가 첫 스테이지 이후 게임을 시작할 때
            if (transform.position.y < 0f && StageManager.Instance.stageNum != 1) return playerArrivePoint * 1000;
            
            return (playerArrivePoint * 1000 + transform.position.y * 10f);
        }
    } 

    // 읽기 전용으로만 쓸 때, 이 값을 불러와도 값에 변화를 주지 못하게 읽기로만 
    public float MaxY
    { get { return maxY; } }

    public float plusAtkDmg;

    public float plusAtkSpd;

    public float plusMaxHp;

    public float moveSpeed;

    public Transform bladesParent;
    public Transform birdsParent;

    public SkillBase twistingBlades;
    public SkillBase followeBirds;

    [SerializeField]
    protected Animator anim;

    protected readonly int hashWalk = Animator.StringToHash("isWalk");
    protected readonly int hashDead = Animator.StringToHash("isDead");


    public abstract void InitData();
}
