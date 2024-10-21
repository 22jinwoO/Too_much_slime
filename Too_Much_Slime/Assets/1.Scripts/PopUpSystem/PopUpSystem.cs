using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public partial class PopUpSystem : Singleton<PopUpSystem>
{
    // 팝업창 게임 오브젝트
    [SerializeField] private GameObject PopUp;

    // OK 버튼 클릭시 호출되는 Func
    public Func<bool> onClickOkay;

    // NO 버튼 클릭시 호출되는 Action
    public Action onClickCancel;

    [SerializeField] private Button popUpYesBtn, popUpNoBtn, slotBtn;

    private void Awake()
    {
        popUpYesBtn.onClick.AddListener(OnClickOkay);
        popUpNoBtn.onClick.AddListener(OnClickCancel);
    }

    // 팝업 오픈 시 호출되는 함수
    public void OpenPopUp(Func<bool> onClickOkay, Action onClickCancel, Button slotBtn)
    {
        this.onClickOkay = onClickOkay;
        this.onClickCancel = onClickCancel;
        this.slotBtn = slotBtn;

        PopUp.SetActive(true);
    }

    // OK 버튼 클릭 시 호출되는 함수
    public void OnClickOkay()
    {
        if (onClickOkay != null)
        {
            // 스킬 카드 레벨업이 성공 했을 때, onClickOkay()의 반대값을 반환하여 SlotBtn의 활성화/비활성화 반영
            slotBtn.interactable = !onClickOkay();
        }

        PopUp.SetActive(false);
    }

    // No 버튼 클릭 시 호출되는 함수
    public void OnClickCancel()
    {
        if (onClickCancel != null)
        {
            onClickCancel();
        }

        PopUp.SetActive(false);
    }
}