using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PopRewards : MonoBehaviour
{

    [Header("Reward UI")]
    [SerializeField] private TMP_Text discountText;

    public class Rewards
    {
        public string value;
        public double weight;
    }

    private Rewards[] rewardItems = {
        new Rewards { value = " 🎉 You got 100% discount!", weight = 0.00001242 },
        new Rewards { value = " 🚚 You got Free Delivery!", weight = 2},
        new Rewards { value = " 🛍️ Buy 1 Get 1 Free!", weight = 1}
    };

    public void ShowRewardMessage()
    {
        if (discountText == null) return;

        string selectedReward = GetWeightedRandomReward();
        discountText.text = selectedReward;
        discountText.gameObject.SetActive(true);

        discountText.alpha = 0;
        discountText.DOFade(1f, 0.5f)
            .OnComplete(() => discountText.DOFade(0f, 1f).SetDelay(2f));
    }

    private string GetWeightedRandomReward()
    {
        double totalWeight = rewardItems.Sum(r => r.weight);
        Debug.Log(string.Format("Total Weight: {0}", totalWeight));

        double randomValue = Random.Range(0f, 1f) * totalWeight;
        Debug.Log(string.Format("Random Value: {0}", randomValue));

        double cumulative = 0;
        foreach (var reward in rewardItems)
        {
            cumulative += reward.weight;
            Debug.Log($"Checking reward: {reward.value}, Cumulative: {cumulative}");
            if (randomValue <= cumulative)
                return reward.value;
        }

        return rewardItems[0].value; // Fallback
    }

}
