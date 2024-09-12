using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitController
{
    /// 유닛 상태에 따른 행동을 수행할 때 호출하는 함수
    public void SetState(unitState state);
}
