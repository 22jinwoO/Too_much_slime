using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryObjPool : MonoBehaviour
{
    // 유닛 프리팹
    [field: SerializeField]
    private MonsterUnitStats MonsterPrefab { get; set; }

    // 오브젝트 풀링을 위한 몬스터 유닛 풀
    public Queue<MonsterUnitStats> Monsters { get; set; }

    private void Awake()
    {
        // 스택 초기화
        Monsters = new Queue<MonsterUnitStats>();

        // 오브젝트 풀링 셋팅하는 함수
        InitObjPool(MonsterPrefab);
    }


    #region # InitObjPool : 오브젝트 풀링 구현해주는 함수
    public void InitObjPool(MonsterUnitStats monsterPref)
    {

        // 오브젝트 풀링을 위해 프리팹 미리 생성
        for (int i = 0; i < 10; i++)
        {
            MonsterUnitStats monsterGameOjbect = Instantiate(monsterPref);

            // 오브젝트 비활성화
            monsterGameOjbect.gameObject.SetActive(false);

            // 인스펙터 창에서 깔끔하게 보이기 위해 팩토리 자식으로 설정
            monsterGameOjbect.transform.SetParent(transform);

            // 오브젝트 풀링 스택의 요소로 추가
            Monsters.Enqueue(monsterGameOjbect);
        }

    }
    #endregion

    // 프리팹 복사하는 함수
    public MonsterUnitStats Instantiate_Prefab()
    {
        MonsterUnitStats monsterPrefab = Instantiate(MonsterPrefab);

        monsterPrefab.gameObject.SetActive(false);

        return monsterPrefab;
    }
}
