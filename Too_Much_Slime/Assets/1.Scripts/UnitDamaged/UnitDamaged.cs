using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDamaged : MonoBehaviour
{
    [SerializeField] BaseUnitStats stats;

    public Transform attacker;

    [SerializeField] private OnDeadEvent deadEvent;

    [SerializeField] private SpriteRenderer sprite;

    private void Awake()
    {
        stats = GetComponent<BaseUnitStats>();
        deadEvent = GetComponent<OnDeadEvent>();

        if(gameObject.CompareTag("Monster")) sprite =GetComponent<SpriteRenderer>();
    }

    public void Damaged(float atkDmg)
    {
        if (Mathf.RoundToInt(stats.curHp) <= 0f) return;

        stats.curHp -= atkDmg;

        if (gameObject.CompareTag("Monster"))
        {

            AudioManager.Instance.audioSource.volume = Random.Range(7.5f, 1f);
            AudioManager.Instance.audioSource.PlayOneShot(AudioManager.Instance.audioClip[0]);
            OnMonsterHit();
            return;
        }
        if (gameObject.CompareTag("Player")) OnPlayerHit();
    }

    private void OnMonsterHit()
    {
        StartCoroutine(nameof(OnHit));

        if (Mathf.RoundToInt(stats.curHp) <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            if (attacker != null) attacker.GetComponent<PlayerAttack>().target = null;
            GameManager.Instance.OnDeadAllMonster -= gameObject.GetComponent<MonsterUnitStats>().UnitDead;
            deadEvent.OnDead(stats, attacker);
        }

    }
    private void OnPlayerHit()
    {
        if (Mathf.RoundToInt(stats.curHp) <= 0)
        {
            deadEvent.OnDead();
        }

    }

    IEnumerator OnHit()
    {
        if(gameObject!=null)
        {
            sprite.color = new Color(0.9f, 0.2f, 0.2f);

            yield return new WaitForSecondsRealtime(0.1f);

            sprite.color = new Color(1f, 1f, 1f);
        }



    }
}
