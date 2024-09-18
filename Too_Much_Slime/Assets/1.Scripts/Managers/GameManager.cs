using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private FadeInOutManager fadeInOutManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private ResultManager resultManager;
    [SerializeField] private ItemLineSpawnManager itemLinSpawnManger;

    [SerializeField] private GameObject lobbyCanvas;
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private PlayerUnitStats player;
    [SerializeField] private TextMeshProUGUI playerMaxTxt;


    public Button gameStartBtn;

    public bool isGameStart = false;

    //델리게이트 선언
    public delegate void monsterAllDead();

    //이벤트 선언
    public event monsterAllDead OnDeadAllMonster;


    private void Awake()
    {
        StartCoroutine(fadeInOutManager.FadeInFadeOut(true));
        
        gameStartBtn.onClick.AddListener(GameStart);
    }

    private void Update()
    {
        if(isGameStart)
        {
            int maxY = Mathf.FloorToInt(player.MaxY);
            playerMaxTxt.text = $"{maxY} m";
        }

        if (gameStartBtn.gameObject.activeSelf && OnDeadAllMonster != null) OnDeadAllMonster();
    }
    public void GameStart()
    {
        spawnManager.Spawn();
        gameStartBtn.gameObject.SetActive(false);
        lobbyCanvas.SetActive(false);
        inGameCanvas.SetActive(true);
        itemLinSpawnManger.CreateItemLine();
        isGameStart = true;
    }

    public IEnumerator GameEnd()
    {
        isGameStart = false;

        yield return new WaitForSecondsRealtime(3f);

        OnDeadAllMonster();
        spawnManager.max_Mons_Ypos = 0f;
        StartCoroutine(resultManager.OnResultPopUp());

        yield return new WaitForSecondsRealtime(2f);

        player.InitData();

    }
}
