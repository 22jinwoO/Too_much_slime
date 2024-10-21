using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    [SerializeField] PlayerSkillManager playerSkillManager;

    [SerializeField] private Transform slotParent;

    [SerializeField] private Slot[] slots;

    [SerializeField] private Button[] slotBtns;

#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
        slotBtns = slotParent.GetComponentsInChildren<Button>();
    }
#endif

    private void Start()
    {
        SetSkillCards();
    }

    public void SetSkillCards()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            int rand = Random.Range(0, playerSkillManager.skillCards.Length);

            // 슬롯의 버튼 활성화
            slotBtns[i].interactable = true;

            // 슬롯의 랜덤한 스킬 카드 할당
            slots[i].skillCard = playerSkillManager.skillCards[rand];

            // 스킬 카드 구매 시 필요한 잼 개수 표시
            slots[i].jamCntTxt.text = playerSkillManager.skillCards[rand].NeedJam.ToString();

            // 스킬 카드 속성 이미지 표시
            slots[i].skillAttribute.sprite = playerSkillManager.skillCards[rand].AtrributeImg;

            // 스킬 아이콘 표시
            slots[i].skillImg.sprite = playerSkillManager.skillCards[rand].SKillImg;

            // 스킬 속성 카드 이름 텍스트 반영
            slots[i].titleTxt.text = playerSkillManager.skillCards[rand].TitleValue;

            // 스킬 속성 카드 내용 텍스트 반영
            slots[i].contentTxt.text = playerSkillManager.skillCards[rand].SkillContentValue;
        }
    }
}
