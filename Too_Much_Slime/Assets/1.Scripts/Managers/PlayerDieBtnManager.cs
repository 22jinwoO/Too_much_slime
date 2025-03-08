using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDieBtnManager : MonoBehaviour
{
    [SerializeField] UnitDamaged playerUnitDamaged;

    [SerializeField] Button playerDieBtn;

    private float deadDmg = 5000;

    private void Awake()
    {
        playerDieBtn.onClick.AddListener(() => playerUnitDamaged.Damaged(deadDmg));
    }
}
