using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        switch (collision.tag)
        {
            case "Monster":
                MonsterUnitStats stats = collision.GetComponent<MonsterUnitStats>();
                stats.gameObject.SetActive(false);
                if (stats.MonsterFactory == null) return;
                stats.MonsterFactory.factory_ObjPool.Monsters.Enqueue(stats);
                stats.gameObject.name = "큐 안으로 들어감";
                break; 

            case "3Jams":
                Destroy(collision.gameObject);
                break;
            case "Jam":
                Destroy(collision.gameObject);
                break;
            case "JamShop":
                Destroy(collision.gameObject);
                break;
            case "ShopLine":
                Destroy(collision.gameObject);
                break;
        }
    }
}
