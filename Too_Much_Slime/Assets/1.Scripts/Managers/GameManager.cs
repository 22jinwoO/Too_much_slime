using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private FadeInOutManager fadeInOutManager;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private GameObject lobbyCanvas;
    [SerializeField] private GameObject inGameCanvas;
    [SerializeField] private PlayerUnitStats player;
    [SerializeField] private TextMeshProUGUI playerMaxTxt;


    public Button gameStartBtn;

    public bool isGameStart = false;

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
    }
    public void GameStart()
    {
        spawnManager.Spawn();
        gameStartBtn.gameObject.SetActive(false);
        lobbyCanvas.SetActive(false);
        inGameCanvas.SetActive(true);
        isGameStart = true;
    }
}
