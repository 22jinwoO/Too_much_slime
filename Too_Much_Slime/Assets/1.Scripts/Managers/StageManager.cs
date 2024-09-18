using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class StageManager : Singleton<StageManager>
{
    [Header("타일맵")]
    [SerializeField]
    private Tilemap mapTile;

    [SerializeField]private TextMeshProUGUI stageTxt;

    public int stageNum = 1;

    private void Awake()
    {
        stageTxt.text = $"STAGE {stageNum}";
    }

    public void StageUpdate()
    {
        stageTxt.text = $"STAGE {stageNum}";
        mapTile.color = new Color(Random.Range(0.702f, 1f), Random.Range(0.695f, 1f), Random.Range(0.752f, 1f));
    }
}
