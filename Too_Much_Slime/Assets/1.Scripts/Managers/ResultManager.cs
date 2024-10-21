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
    [SerializeField] private TextMeshProUGUI stageNumTxt, maxDistanceTxt, player_MaxdistanceTxt;

    [SerializeField] private Button golobbynBtn;

    public bool isFinish;

    private void Awake()
    {
        golobbynBtn.onClick.AddListener(() => StartCoroutine(nameof(GoLobby)));
        isFinish = false;
    }

    public IEnumerator OnResultPopUp()
    {
        maxDistance_Gage.fillAmount = 0f;
        player.moveSpeed = 0f;

        maxDistanceTxt.text = $"{StageManager.Instance.stageNum * 1000f}m";

        resultPopUp.SetActive(true);

        yield return null;

        // 플레이어의 MaxY를 기준으로 maxDistance_Gage의 fillAmount 조정
        float value = 0f;

        float increment = 10f;

        float playerMaxValue = player.MaxY;

        if(playerMaxValue >= 1000f) playerMaxValue -= (StageManager.Instance.stageNum - 1) * 1000;

        // 0부터 playerMaxValue까지 10씩 증가
        while (value < playerMaxValue)
        {
            // player.MaxY에 가까워지면 증가량을 1로 줄임
            if (increment != 1f && player.MaxY - increment < 10f) increment = 1f;  // 더 세밀하게 증가

            value += increment;

            maxDistance_Gage.fillAmount = value / 1000f;

            yield return new WaitForSeconds(0.01f);
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
        player.InitData();

        stageNumTxt.gameObject.SetActive(false);

        lobbyCanvas.SetActive(true);

        StartCoroutine(fadeInOutManager.FadeInFadeOut(false));

        yield return new WaitForSecondsRealtime(2f);

        resultPopUp.SetActive(false);
        maxDistanceResult.gameObject.SetActive(false);

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

        stageNumTxt.gameObject.SetActive(true);

        yield return null;

        gameManager.gameStartBtn.gameObject.SetActive(true);

    }
}
