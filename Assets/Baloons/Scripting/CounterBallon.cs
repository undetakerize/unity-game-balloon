using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Baloons.Scripting
{

    public class CounterBallon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private TMP_Text counterText;
        [SerializeField] private Transform scaleTarget;
        public float scaleMultiplier = 1.2f;
        private int currentCount = 0;
        private float originalScaleY;

        private void Awake()
        {
            if (scaleTarget == null)
                scaleTarget = transform;

            originalScaleY = 1;
        }

        public void IncrementCounter()
        {
            int fromValue = currentCount;
            currentCount++;
            AnimateCounter(fromValue, currentCount);
        }

        public void ResetCounter()
        {
            currentCount = 0;
            counterText.text = "0";
        }

        private void AnimateCounter(int fromValue, int toValue)
        {
            if (counterText == null) return;

            DOTween.To(() => fromValue, x =>
            {
                counterText.text = x.ToString();
            }, toValue, 0.3f).SetEase(Ease.OutQuad);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            scaleTarget.DOScaleY(originalScaleY * scaleMultiplier, 0.2f).SetEase(Ease.OutBack);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            scaleTarget.DOScaleY(originalScaleY, 0.2f).SetEase(Ease.OutBack);
        }
    }
}
