using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreeenSlimeFactory : MonoBehaviour, IMonsterFactory
{
    public FactoryObjPool factory_ObjPool { get; set; }

    private void Awake()
    {
        factory_ObjPool = GetComponent<FactoryObjPool>();
    }


    // 생산될 유닛을 결정해주는 구상 생산자
    public MonsterUnitStats CreateMonsterUnit()
    {
        MonsterUnitStats MonsterUnit = null;

        print(factory_ObjPool.Monsters);
        print(factory_ObjPool.Monsters.Count);
        // 스택 요소가 0보다 클 경우
        if (factory_ObjPool.Monsters.Count > 0)
        {
            MonsterUnit = factory_ObjPool.Monsters.Dequeue();
        }

        // 스택 요소가 0 보다 작을 경우 요소 추가
        else
        {
            MonsterUnit = factory_ObjPool.Instantiate_Prefab();

            // 인스펙터 창에서 깔끔하게 보이기 위해 팩토리 자식으로 설정
            MonsterUnit.transform.SetParent(transform);
        }

        MonsterUnitStats monsterData = MonsterUnit.GetComponent<MonsterUnitStats>();

        monsterData.MonsterFactory = this;

        // 생성된 몬스터 반환
        return MonsterUnit;
    }

}
