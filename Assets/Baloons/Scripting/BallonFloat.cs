using DG.Tweening;
using UnityEngine;

public class BalloonFloat : MonoBehaviour
{
    public float floatHeight = 0.5f;
    public float floatDuration = 1.5f;

    void Start()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOLocalMoveY(transform.localPosition.y + 0.5f, 1.5f).SetEase(Ease.InOutSine));
        s.Join(transform.DOLocalMoveX(transform.localPosition.x + 0.2f, 1.5f).SetEase(Ease.InOutSine));
        s.Append(transform.DOLocalMoveY(transform.localPosition.y, 1.5f).SetEase(Ease.InOutSine));
        s.Join(transform.DOLocalMoveX(transform.localPosition.x, 1.5f).SetEase(Ease.InOutSine));
        s.SetLoops(-1);
    }
}