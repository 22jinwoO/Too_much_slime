using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    [SerializeField] PlayerSkillManager playerSkillManager;

    [SerializeField]
    private Transform slotParent;

    [SerializeField]
    private Slot[] slots;

    [SerializeField]
    private Button slotBtn;

#if UNITY_EDITOR
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
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
            slots[i].skillCard = playerSkillManager.skillCards[rand];
            slots[i].jamCntTxt.text = playerSkillManager.skillCards[rand].NeedJam.ToString();
            slots[i].skillAttribute.sprite = playerSkillManager.skillCards[rand].AtrributeImg;
            slots[i].skillImg.sprite = playerSkillManager.skillCards[rand].SKillImg;
            slots[i].titleTxt.text = playerSkillManager.skillCards[rand].TitleValue;
            slots[i].contentTxt.text = playerSkillManager.skillCards[rand].SkillContentValue;
        }
    }

}
