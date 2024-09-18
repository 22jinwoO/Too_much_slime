using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public partial class PopUpSystem : Singleton<PopUpSystem>
{
    //
    [SerializeField]
    private GameObject PopUp;

    Action onClickOkay;
    Action onClickCancel;

    [SerializeField]
    private Button popUpYesBtn, popUpNoBtn;

    public void OpenPopUp(Action onClickOkay, Action onClickCancel)
    {
        this.onClickOkay = onClickOkay;
        this.onClickCancel = onClickCancel;

        PopUp.SetActive(true);
    }

    public void OnClickOkay()
    {
        if (onClickOkay != null)
        {
            onClickOkay();
        }

        PopUp.SetActive(false);
    }

    public void OnClickCancel()
    {
        if (onClickCancel != null)
        {
            onClickCancel();
        }

        PopUp.SetActive(false);
    }

    private void Awake()
    {
        popUpYesBtn.onClick.AddListener(OnClickOkay);
        popUpNoBtn.onClick.AddListener(OnClickCancel);
    }
}