using UnityEngine;
using DG.Tweening;

public class DoTweenUtil
{
    public static Tween DoAnchoredPos(RectTransform rect, Vector2 startPos, Vector2 endPos, float duration, Ease ease)
    {
        rect.anchoredPosition = startPos;
        Tween tween = rect.DOAnchorPos(endPos, duration).SetEase(ease);

        return tween;
    }
}
