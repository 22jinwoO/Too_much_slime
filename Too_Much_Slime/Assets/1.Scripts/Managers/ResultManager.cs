using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResultManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private FadeInOutManager fadeInOutManager;
    [SerializeField] private SpawnManager spawnManager;


    [SerializeField] private GameObject resultPopUp;
    [SerializeField] private GameObject maxDistanceResult;

    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private GameObject lobbyCanvas;

    [SerializeField] private PlayerUnitStats player;

    [SerializeField] private Image maxDistance_Gage;
    [SerializeField] private TextMeshProUGUI player_MaxdistanceTxt;

    [SerializeField] private Button golobbynBtn;

    public bool isFinish;

    private void Awake()
    {
        golobbynBtn.onClick.AddListener(() => StartCoroutine(nameof(GoLobby)));
        isFinish = false;
    }

    public IEnumerator OnResultPopUp()
    {
        resultPopUp.SetActive(true);

        yield return null;

        // 플레이어의 MaxY를 기준으로 maxDistance_Gage의 fillAmount 조정
        float value = 0f;

        // 0부터 player.MaxY까지 1씩 증가
        while (value < player.MaxY)
        {
            maxDistance_Gage.fillAmount = value / 1000f;
            value += 1;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.2f);
        print(Mathf.RoundToInt(player.MaxY));
        player_MaxdistanceTxt.text = $"{Mathf.RoundToInt(player.MaxY)}m";
        maxDistanceResult.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(3f);

        golobbynBtn.gameObject.SetActive(true);

    }

    public IEnumerator GoLobby()
    {
        lobbyCanvas.SetActive(true);

        yield return null;

        StartCoroutine(fadeInOutManager.FadeInFadeOut(false));

        yield return new WaitForSecondsRealtime(2f);

        resultPopUp.SetActive(false);

        inGameCanvas.SetActive(false);

        // 보스 생성이 아닌 보스 처치 시 로 바껴야함
        if (isFinish)
        {
            StageManager.Instance.stageNum++;
            StageManager.Instance.StageUpdate();
        }

        gameManager.isGameStart = false;
        spawnManager.max_Mons_Ypos = 0f;
        yield return null;

        spawnManager.isBossSpawned = false;
        spawnManager.AllDestroy();
        player.InitData();
        yield return new WaitForSecondsRealtime(1f);
        isFinish = false;
        StartCoroutine(fadeInOutManager.FadeInFadeOut(true));

        gameManager.gameStartBtn.gameObject.SetActive(true);

    }
}
