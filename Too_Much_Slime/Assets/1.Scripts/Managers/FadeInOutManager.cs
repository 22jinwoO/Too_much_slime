using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutManager : MonoBehaviour
{
    [SerializeField]
    private Image fadeInFadeOutImg;    // 페이드인 페이드 아웃 이미지

    public IEnumerator FadeInFadeOut(bool FadeInOutCheck)  // 화면 페이드인 페이드 아웃 해주는 함수
    {
        Color color = fadeInFadeOutImg.color;

        fadeInFadeOutImg.gameObject.SetActive(true);

        if (FadeInOutCheck) // 페이드 인 상황일 때
        {
            float time = 1;
            while (time >= 0f)
            {
                color.a = time;
                fadeInFadeOutImg.color = color;
                time -= Time.deltaTime * 0.45f;
                yield return null;
            }
            fadeInFadeOutImg.gameObject.SetActive(false);

        }

        else  // 페이드 아웃 상황일 때
        {
            float time = 0;
            while (time <= 1f)
            {
                print("페이드아웃");
                color.a = time;
                fadeInFadeOutImg.color = color;
                time += Time.deltaTime * 0.45f;
                yield return null;
            }

        }
    }
}
