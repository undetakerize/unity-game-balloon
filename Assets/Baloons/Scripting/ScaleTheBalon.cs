using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleTheBalon : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource pumpAudioSource;
    [SerializeField] private AudioClip pumpClip;
    [SerializeField] private AudioClip pumpBlastClip;
    [SerializeField] private GameObject sparklePreFab;
    public Transform targetToScale;
    public float scaleMultiplier = 0.3f;
    public float duration = 0.2f;
    public float maxScale = 1.2f;
    public GameObject baloonHd;
    [Header("Pump Counter")]
    [SerializeField] private CounterBallon counterBallon;
    private bool balloonPopped = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (balloonPopped || targetToScale == null) return;

        float currentScale = targetToScale.localScale.x;

        if (currentScale >= maxScale) return;

        Vector3 newScale = targetToScale.localScale * scaleMultiplier;
        targetToScale.DOScale(newScale, duration).SetEase(Ease.OutBack)
            .OnUpdate(CheckSprite);

        if (pumpAudioSource != null && pumpClip != null)
        {
            pumpAudioSource.PlayOneShot(pumpClip);
        }

        counterBallon?.IncrementCounter();
    }

    private void CheckSprite()
    {
        float scaleX = targetToScale.localScale.x;
        if (scaleX >= 1.2f && !balloonPopped)
        {
            balloonPopped = true;
            animator.SetTrigger("Pop");
            if (pumpAudioSource != null & pumpBlastClip != null)
            {
                pumpAudioSource.PlayOneShot(pumpBlastClip);
            }
            GameObject confetti = Instantiate(sparklePreFab, baloonHd.transform.position, Quaternion.identity);

            // Play particle system manually
            var ps = confetti.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }

            // Optional: Destroy the confetti after some time
            Destroy(confetti, 5f);
            StartCoroutine(DestroyAfterAnimation());
        }

    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(0.5f); // Match this with your pop animation length
        Destroy(baloonHd);
    }
}
