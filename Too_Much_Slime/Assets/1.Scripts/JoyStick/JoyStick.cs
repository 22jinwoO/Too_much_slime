using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform rect_BackGround;
    [SerializeField] private RectTransform rect_JoyStick;

    // 조이스틱 이동 값
    public Vector2 value;

    public float moveSpeed;

    // 조이스틱 백그라운드의 반지름 값
    private float radius;

    // 터치 인식 확인하는 변수
    [SerializeField] bool isTouch = false;

    // 플레이어에게 이동 신호를 보낼 delegate
    public Action<Vector2, float> OnMoveInput;  // 이동 방향, 조이스틱 레버의 거리(0~1)

    private void Awake()
    {
        // 조이스틱 배경으로 원 반지름 구하기
        radius = rect_BackGround.rect.width * 0.5f;
    }

    // 터치 다운 이벤트를 받아서 조이스틱 활성화 및 위치 조정
    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;

        // 조이스틱을 터치한 위치로 이동
        rect_BackGround.position = eventData.position;

        // 조이스틱 활성화
        rect_BackGround.gameObject.SetActive(true);
    }

    // 손가락 뗄 때 or 마우스 클릭에서 손을 뗼 때 실행되는 부분
    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;

        // 조이스틱 위치를 원상복귀 시키기 위해 자식 위치를 zero로 변경
        rect_JoyStick.localPosition = Vector2.zero;

        value = Vector2.zero;

        // 이동 신호 전달 (방향 0, 거리 0)
        OnMoveInput?.Invoke(value, value.magnitude);

        rect_BackGround.gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isTouch)
        {
            // 마우스 현재 위치에서 조이스틱 배경의 위치값을 빼주기 => 이동 방향 구하기
            value = eventData.position - (Vector2)rect_BackGround.position;

            // 이동방향 위치 value 값을 value 값부터 조이스틱 배경의 반지름 값만큼 제한하기
            value = Vector2.ClampMagnitude(value, radius);

            // 조이스틱 자식 위치를 value 값으로 지정
            rect_JoyStick.localPosition = value;

            // 조이스틱 거리에 따라 이동속도 영향 주기
            float distance = Vector2.Distance(rect_BackGround.position, rect_JoyStick.position) / radius;

            // 방향 벡터 구하기
            value = value.normalized;

            // 방향과 레버 거리를 delegate를 통해 전달
            OnMoveInput?.Invoke(value, distance);  // 거리 값은 0 ~ 1 사이

        }
    }
}

