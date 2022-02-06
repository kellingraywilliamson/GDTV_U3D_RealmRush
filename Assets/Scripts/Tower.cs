using UnityEngine;

namespace RealmRush
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private int cost = 75;

        public bool CreateTower(Tower tower, Vector3 position)
        {
            var bank = FindObjectOfType<Bank>();

            if (!bank) return false;
            if (bank.CurrentBalance < cost) return false;

            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
    }
}
