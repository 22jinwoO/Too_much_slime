using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private PlayerUnitStats player;

    public Transform spawnser;

    public float max_Mons_Ypos;

    [SerializeField]
    private GameObject monsterFactoryManager;

    [SerializeField] private BossFactory bossrFactory;
    [SerializeField] private IMonsterFactory[] monsterFactorys;

    public bool isBossSpawned = false; // 보스 몬스터 생성 여부를 체크하는 플래그
    
    public float maxSpawnPoint;

    public List<GameObject> spawners = new List<GameObject>();

    private void Awake()
    {
        maxSpawnPoint = 85f;
        monsterFactorys = monsterFactoryManager.GetComponentsInChildren<IMonsterFactory>();
    }

    private void Update()
    {
        if (gameManager.isGameStart&& max_Mons_Ypos < maxSpawnPoint && player.MaxY / 10f > max_Mons_Ypos - 50f) Spawn();

        // 플레이어의 yPos가 80 이상이고, 보스가 아직 생성되지 않았다면 보스 몬스터 생성
        if ((player.MaxY / 10) > maxSpawnPoint && !isBossSpawned)
        {
            SpawnBoss();
        }
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

            if ((max_Mons_Ypos + randY) % 10 == 0) continue;

            SpawnMonster(boardPositionList, randY);

            int randSpawnJam = Random.Range(0, 2);

            if(randSpawnJam == 0) SpawnJam(boardPositionList, randY);


            boardPositionList.Clear();
            max_Mons_Ypos += randY;
            count += randY;
        }
    }
    public void SpawnMonster(List<int> boardPositionList, float randY)
    {
        int randMonsterCnt = Random.Range(0, 5);

        for (int i = 0; i < randMonsterCnt; i++)
        {
            if (max_Mons_Ypos + randY > maxSpawnPoint)
            {
                max_Mons_Ypos = maxSpawnPoint;
                randY = 0;
                break;
            }


            // 위치값 정하기
            int randX = Random.Range(0, boardPositionList.Count);

            MonsterUnitStats prefab = monsterFactorys[0].CreateMonsterUnit();

            GameManager.Instance.OnDeadAllMonster += prefab.UnitDead;

            prefab.transform.position = new Vector2(boardPositionList[randX], max_Mons_Ypos + randY);

            prefab.InitData(StageManager.Instance.stageNum);

            prefab.gameObject.SetActive(true);

            boardPositionList.RemoveAt(randX);
        }
    }
    // 보스 몬스터를 생성하는 함수
    public void SpawnBoss()
    {
        // 보스 몬스터 팩토리에서 보스 몬스터 생성 (monsterFactorys[1]이 보스 팩토리라고 가정)
        MonsterUnitStats bossPrefab = bossrFactory.CreateMonsterUnit(); // 보스 몬스터 팩토리에서 생성
        bossPrefab.transform.position = bossrFactory.bossSpawnPoint.position;
        bossPrefab.InitData(StageManager.Instance.stageNum); // 보스 몬스터의 데이터를 초기화 (레벨 또는 체력 설정)

        bossPrefab.gameObject.SetActive(true);

        // 보스 몬스터가 한 번만 생성되도록 플래그 설정
        isBossSpawned = true;

        // 보스가 생성된 위치를 업데이트
        max_Mons_Ypos += 5;

        bossPrefab.transform.SetParent(spawnser);
        spawners.Add(bossPrefab.gameObject);
    }

    public GameObject jam;

    public void SpawnJam(List<int> boardPositionList, float randY)
    {
        int randJamCnt = Random.Range(0, 3);

        for (int i = 0; i < randJamCnt; i++)
        {
            if (max_Mons_Ypos + randY > maxSpawnPoint)
            {
                max_Mons_Ypos = maxSpawnPoint;
                randY = 0;
                break;
            }


            // 위치값 정하기
            if (boardPositionList.Count == 0) return;

            int randX = Random.Range(0, boardPositionList.Count);

            GameObject jamPrefab = Instantiate(jam);

            jamPrefab.transform.position = new Vector2(boardPositionList[randX], max_Mons_Ypos + randY);

            jamPrefab.transform.SetParent(spawnser);
            spawners.Add(jamPrefab);

            boardPositionList.RemoveAt(randX);
        }
    }

    public void AllDestroy()
    {

        for(int i=0; i < spawners.Count; i++)
        {
            Destroy(spawners[i]);
        }
        
        
    }
}
