using UnityEngine;

namespace RealmRush
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private Tower towerPrefab;
        [SerializeField] private bool isPlaceable = true;
        public bool IsPlaceable => isPlaceable;

        private void OnMouseDown()
        {
            if (!isPlaceable) return;
            var towerPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !towerPlaced;
        }
    }
}
