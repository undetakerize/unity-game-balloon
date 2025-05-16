using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleToOtherObject : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    public Transform targetToScale; // Drag Baloon_hd here
    public float scaleUpFactor = 1.2f; // Desired scale (1.2 = 120%)
    public float duration = 0.2f;
    private Vector3 originalScale;
    private Vector3 newScale;

    void Start()
    {
        if (targetToScale == null)
            targetToScale = transform;

        originalScale = targetToScale.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        newScale = targetToScale.localScale * scaleUpFactor;
        targetToScale.DOScale(newScale, duration).SetEase(Ease.OutBack);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("UP");
        targetToScale.DOScale(newScale, duration);
    }

}
