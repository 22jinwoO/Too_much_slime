using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitController : BaseUnitController, IUnitController
{
    
    public IUnitDoAct playerMove;
    public IUnitDoAct playerAttack;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();

        UnitState = unitState.Move;
        SetState(UnitState);
    }

    
    public void SetState(unitState state)
    {
        UnitState = state;

        switch (UnitState)
        {
            // 유닛 이동
            case unitState.Move:
                if (UnitAct == null)
                {
                    UnitAct = playerMove;
                    UnitAct.Enter();
                }
                break;

            // 유닛 공격 상태
            case unitState.Attack:
                if (UnitAct == null)
                {
                    //UnitAct = unitAtk;
                    UnitAct.Enter();
                }
                break;
        }
    }
}
