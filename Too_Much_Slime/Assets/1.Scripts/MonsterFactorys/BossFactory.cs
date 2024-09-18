using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : MonoBehaviour
{
    public MonsterUnitStats[] bossList;

    public Transform bossSpawnPoint;

    public MonsterUnitStats CreateMonsterUnit()
    {
        MonsterUnitStats monsterPrefab = Instantiate(bossList[0]);
        return monsterPrefab;
    }
}
