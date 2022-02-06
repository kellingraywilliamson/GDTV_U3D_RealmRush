using System;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace RealmRush
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private int startingBalance = 150;
        [SerializeField] private TextMeshProUGUI accountLabel;

        public int CurrentBalance { get; private set; }

        // Start is called before the first frame update
        private void Awake()
        {
            CurrentBalance = startingBalance;
        }

        private void Start()
        {
            UpdateAccountLabel();
        }

        public void Deposit(int amount)
        {
            if (amount <= 0) return;
            CurrentBalance += amount;
            UpdateAccountLabel();
        }

        public void Withdraw(int amount)
        {
            if (amount <= 0) return;
            CurrentBalance -= amount;
            UpdateAccountLabel();

            if (CurrentBalance < 0)
            {
                ReloadScene();
            }
        }

        private void UpdateAccountLabel()
        {
            if (!accountLabel) return;
            accountLabel.text = $"Gold: {CurrentBalance}";
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
