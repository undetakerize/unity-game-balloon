using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Baloons.Scripting
{
    public class ScaleOnTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Vector3 originalScale;
        public float scaleMultiplier = 1.2f;
        public float duration = 0.2f; // animation duration

        private void Start()
        {
            originalScale = transform.localScale;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            transform.DOScale(originalScale * scaleMultiplier, duration).SetEase(Ease.OutBack);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.DOScale(originalScale, duration).SetEase(Ease.OutBack);
        }
    }
}
