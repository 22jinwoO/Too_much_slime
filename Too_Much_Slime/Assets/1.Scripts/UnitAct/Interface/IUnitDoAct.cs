using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitDoAct
{
    // 상태 진입 시 호출
    public void Enter();

    // 상태 중 행동 호출
    public void DoAction();

    // 상태 전환 시 호출
    public void Exit();
}
