using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public SkillCardBase skillCard;
    public Image skillAttribute;
    public Image skillImg;

    public TextMeshProUGUI titleTxt;
    public TextMeshProUGUI contentTxt;
    public TextMeshProUGUI jamCntTxt;

    [SerializeField] private Button mySlotBtn;

    private void Awake()
    {
        mySlotBtn= GetComponent<Button>();

        mySlotBtn.onClick.AddListener(() =>
        {
            PopUpSystem.Instance.OpenPopUp(skillCard.LevelUpAction, null , mySlotBtn);
        });
    }
}
