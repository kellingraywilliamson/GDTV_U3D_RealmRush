using RealmRush;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int goldReward = 25;
    [SerializeField] private int goldPenalty = 25;
    private Bank _bank;

    private void Start()
    {
        _bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (!_bank) return;
        _bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (!_bank) return;
        _bank.Withdraw(goldPenalty);
    }
}
