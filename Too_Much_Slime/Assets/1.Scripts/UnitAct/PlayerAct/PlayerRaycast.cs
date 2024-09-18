using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize;  // 박스의 가로 0.45, 세로 0.4 크기
    [SerializeField] private float rayDistance;                 // Ray의 길이
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private LayerMask monsterLayerMask;             // Monster 레이어 마스크

    private void Awake()
    {
        boxSize = new Vector2(0.45f, 0.4f);
        rayDistance = 0.8f;
        playerAttack= GetComponent<PlayerAttack>();
    }
    void Update()
    {
        // 플레이어의 Y축 방향으로 Ray 쏘기
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, Vector2.up, rayDistance, monsterLayerMask);

        // 충돌한 오브젝트가 있는지 확인
        if (hit.collider != null)
        {
            // 충돌한 오브젝트의 태그가 "Monster"인지 확인
            if (hit.collider.CompareTag("Monster"))
            {
                if (playerAttack.target == null) playerAttack.target = hit.collider.GetComponent<UnitDamaged>();
            }
        }
        else if(hit.collider == null) playerAttack.target = null;
    }

    // 박스 캐스트의 시각적 디버그를 위한 Gizmo 그리기
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up * rayDistance, boxSize);
    }
}
