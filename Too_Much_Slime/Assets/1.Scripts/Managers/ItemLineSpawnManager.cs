using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLineSpawnManager : MonoBehaviour
{
    public SpawnManager spawnManager;

    public GameObject shopLinePrefab;

    public void CreateItemLine()
    {
        print("함수 실행" + spawnManager.maxSpawnPoint);
        for (int i = 0; i < spawnManager.maxSpawnPoint; i += 10)
        {
            GameObject prefab = Instantiate(shopLinePrefab, Vector3.zero + new Vector3(0, i, 0), Quaternion.identity);
            prefab.transform.SetParent(spawnManager.spawnser);
            spawnManager.spawners.Add(prefab);
        }
            
    }

}
