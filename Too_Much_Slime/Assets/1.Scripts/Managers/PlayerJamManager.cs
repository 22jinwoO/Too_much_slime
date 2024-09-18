using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerJamManager : Singleton<PlayerJamManager>
{
    public int playerJamCnt;
    public TextMeshProUGUI jamCntTxt;

    public void GetJam(int jamCnt)
    {
        playerJamCnt += jamCnt;
        jamCntTxt.text = $"{playerJamCnt.ToString()}";

    }
}
