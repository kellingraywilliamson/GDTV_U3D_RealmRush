using UnityEngine;

namespace RealmRush
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private bool isPlaceable = true;
        public bool IsPlaceable => isPlaceable;

        private void OnMouseDown()
        {
            if (!isPlaceable) return;

            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
