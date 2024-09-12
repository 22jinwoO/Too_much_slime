using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IUnitDoAct
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private PlayerUnitStats stats;
    [SerializeField] private JoyStick joyStick;

    // 조이스틱으로부터 받은 이동 방향 (X축만)
    private Vector2 movementDirection;

    // 자동으로 이동할 y축 속도
    [SerializeField] private float autoMoveSpeedY;  // 원하는 속도로 설정 가능    
    
    // x축 속도
    [SerializeField] private float autoMoveSpeedX;  // 원하는 속도로 설정 가능

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerUnitStats>();
        autoMoveSpeedY = 2f;
        autoMoveSpeedX = 900f;
    }

    public void Enter()
    {
        joyStick.OnMoveInput += OnMovementInput;

    }

    public void DoAction()
    {
        // 조이스틱의 x축 방향으로만 이동
        float moveX = movementDirection.x * autoMoveSpeedX;

        // y축은 자동으로 이동 (일정한 속도)
        float moveY = autoMoveSpeedY;

        // 플레이어의 이동
        rigid.velocity = new Vector2(moveX, moveY * stats.moveSpeed)  * Time.deltaTime;
    }

    public void Exit()
    {
    }

    // 이동 입력을 처리하는 delegate의 콜백 함수
    private void OnMovementInput(Vector2 direction)
    {
        // 전달받은 조이스틱 입력에서 x축 값만 저장
        movementDirection = new Vector2(direction.x, 0);  // y값은 무시하고 x값만 사용;


        // 유저가 원하는 방향으로 이동하는 로직
        // 입력 받기
        float moveX = direction.x;

        //bool isMove = moveX == 0;

        //if (isMove) Exit();
    }
}
