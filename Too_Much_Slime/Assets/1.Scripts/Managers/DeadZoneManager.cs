using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Monster":
                MonsterUnitStats stats = collision.GetComponent<MonsterUnitStats>();
                stats.gameObject.SetActive(false);
                stats.MonsterFactory.factory_ObjPool.Monsters.Enqueue(stats);
                stats.gameObject.name = "큐 안으로 들어감";
                break;
            default:
                break;
        }
    }
}
