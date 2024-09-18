using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKingSlimeSkill : MonoBehaviour, IBossSkill
{
    [SerializeField] private MonsterUnitStats stats;

    public int[] respawnPoints;

    public Projectile greenJelly;

    public float greenJellyDmg;
    public float greenJellySpd;

    [SerializeField] private Vector2 boxSize;  // 박스의 가로 0.45, 세로 0.4 크기
    [SerializeField] private float rayDistance;                 // Ray의 길이
    [SerializeField] private LayerMask targetLayerMask;        // Monster 레이어 마스크
    [SerializeField] private bool isSearch;        // Monster 레이어 마스크

    private void Awake()
    {
        isSearch = false;
        rayDistance = -3f;

        boxSize = new Vector2(5f, 4f);
        stats =GetComponent<MonsterUnitStats>();
        InitData();
        
    }


    void Update()
    {
        if (!isSearch) ShootRay();
    }

    // 박스 캐스트의 시각적 디버그를 위한 Gizmo 그리기
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.up * rayDistance, boxSize);
    }
    public void DoSkill()
    {
        int rand = Random.Range(0, respawnPoints.Length);

        Instantiate(greenJelly.gameObject, new Vector3(respawnPoints[rand], transform.position.y + 7f, 0f), Quaternion.identity);

        Invoke(nameof(DoSkill), Random.Range(0.1f, 1.2f));

    }


    public void InitData()
    {
        respawnPoints = new int[] { -2, -1, 0, 1, 2 };
        greenJellyDmg = 20f;
        greenJellySpd = 500f;
        greenJelly.attackDmg = stats.atkDmg += greenJellyDmg;
        greenJelly.MoveSpeed = greenJellySpd;
    }

    public void ShootRay()
    {
        // 플레이어의 Y축 방향으로 Ray 쏘기
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, Vector2.down, rayDistance, targetLayerMask);

        // 충돌한 오브젝트가 있는지 확인
        if (hit.collider != null)
        {
            // 충돌한 오브젝트의 태그가 "Monster"인지 확인
            if (hit.collider.CompareTag("Player"))
            {
                isSearch = true;
                Invoke(nameof(DoSkill), Random.Range(0.1f, 1.2f));
            }
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
