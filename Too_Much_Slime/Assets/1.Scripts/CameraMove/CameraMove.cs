using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Camera m_Camera;
    [SerializeField] Transform player;

    private void Awake()
    {
        m_Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
// 플레이어의 위치를 x축에서 -0.1에서 0.1로 제한
        Vector3 clampedPosition = m_Camera.transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -0.1f, 0.1f); // x축 제한을 -0.1 ~ 0.1로 변경
        m_Camera.transform.position = clampedPosition;

        Vector3 targetPos = new Vector3(0, player.transform.position.y + 2f, -10);

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime*2f);
    }

}
