using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    public float fadeTime = 1;
    public RectTransform rectTransform;
    public CanvasGroup canvasGroup;

    public void FadeIn()
    {
        canvasGroup.alpha = 0;
        rectTransform.transform.localScale = new  Vector3(0, -1000f, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
    }

    public void FadeOut()
    {
        canvasGroup.alpha = 1;
        rectTransform.transform.localScale = new Vector3(0, 0, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);    
    }
}
