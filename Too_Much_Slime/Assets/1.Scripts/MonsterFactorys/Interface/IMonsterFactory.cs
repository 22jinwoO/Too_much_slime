using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterFactory
{
    public FactoryObjPool factory_ObjPool { get; set; }

    // 유닛 생산하는 생성자 함수
    public MonsterUnitStats CreateMonsterUnit();

}