using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishEvent : MonoBehaviour
{
    [SerializeField] private ResultManager resultManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            resultManager.isFinish = true;
            StartCoroutine(resultManager.OnResultPopUp());
        }
    }
}
