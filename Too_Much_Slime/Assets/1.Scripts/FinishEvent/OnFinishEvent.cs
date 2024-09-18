using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishEvent : MonoBehaviour
{
    [SerializeField] private ResultManager resultManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        resultManager.isFinish = true;
        if (collision.CompareTag("Player")) StartCoroutine(resultManager.OnResultPopUp());
    }
}
