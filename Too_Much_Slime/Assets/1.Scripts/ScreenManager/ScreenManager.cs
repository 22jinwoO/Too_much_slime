using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [Header("해상도 대응해야 하는 카메라들")]
    [SerializeField] private Camera camera;

    private void Awake()
    {
            // 해상도 대응해야하는 카메라의 rect값
            Rect rect = camera.rect;

            // 해상도 가로 길이 - 9 (9:16)
            float scaleHeight = ((float)Screen.width / Screen.height) / ((float)9 / 16);

            // 해상도 세로 길이 - 16
            float scaleWidth = 1f / scaleHeight;

            //해상도 가로 길이가 1보다 작을 때
            if (scaleHeight < 1)
            {
                rect.height = scaleHeight;
                rect.y = (1f - scaleHeight) / 2f;
            }

            else
            {
                rect.width = scaleWidth;
                rect.x = (1f - scaleWidth) / 2f;
            }
            camera.rect = rect;
    }
}
