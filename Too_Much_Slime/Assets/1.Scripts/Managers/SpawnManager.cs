using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private PlayerUnitStats player;

    [SerializeField] float max_Mons_Ypos;

    [SerializeField]
    private GameObject monsterFactoryManager;

    [SerializeField] private IMonsterFactory[] monsterFactorys;

    private void Awake()
    {
        monsterFactorys = monsterFactoryManager.GetComponentsInChildren<IMonsterFactory>();

    }

    private void Update()
    {
        if (gameManager.isGameStart&& max_Mons_Ypos < 200f && player.MaxY > max_Mons_Ypos - 50f) Spawn();
    }

    public void Spawn()
    {
        List<int> boardPositionList = new List<int>();

        int count = 0;

        while (count <= 100)
        {
            for (int i = -2; i < 3; i++)
            {
                boardPositionList.Add(i);
            }

            int randY = Random.Range(1, 3);
            int randMonsterCnt = Random.Range(0, 5);

            for (int i = 0; i < randMonsterCnt; i++)
            {
                if (max_Mons_Ypos + randY > 200)
                {
                    max_Mons_Ypos = 200;
                    randY = 0;
                    break;
                }



                int randX = Random.Range(0, boardPositionList.Count);

                MonsterUnitStats prefab = monsterFactorys[0].CreateMonsterUnit();

                prefab.transform.position = new Vector2(boardPositionList[randX], max_Mons_Ypos + randY);

                prefab.InitData(1);

                prefab.gameObject.SetActive(true);

                boardPositionList.RemoveAt(randX);
            }

            boardPositionList.Clear();
            max_Mons_Ypos += randY;
            count += randY;
        }
    }
}
