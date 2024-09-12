using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnitController : MonoBehaviour
{
    public BaseUnitStats UnitData { get; set; }

    /// 유닛의 현재 상태
    public unitState UnitState { get; set; }

    /// 클래스들의 접근점(인터페이스)
    public IUnitDoAct UnitAct { get; set; }
}
