using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Shop shop;

    [SerializeField] private Button exitBtn;
    [SerializeField] private Button reloadBtn;

    private void Awake()
    {
        exitBtn.onClick.AddListener(ShopClose);
        reloadBtn.onClick.AddListener(OnReload);
    }

    public void OnReload()
    {
        if (PlayerJamManager.Instance.playerJamCnt < 2) return;

        shop.SetSkillCards();
        PlayerJamManager.Instance.playerJamCnt -= 2;
        PlayerJamManager.Instance.jamCntTxt.text = PlayerJamManager.Instance.playerJamCnt.ToString();
    }

    public void ShopClose()
    {
        shop.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShopOpen()
    {
        shop.SetSkillCards();
        shop.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
