using UnityEngine;
using UnityEngine.SceneManagement;

namespace RealmRush
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private int startingBalance = 150;

        public int CurrentBalance { get; private set; }

        // Start is called before the first frame update
        private void Awake()
        {
            CurrentBalance = startingBalance;
        }

        public void Deposit(int amount)
        {
            if (amount <= 0) return;
            CurrentBalance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount <= 0) return;
            CurrentBalance -= amount;

            if (CurrentBalance < 0)
            {
                ReloadScene();
            }
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
