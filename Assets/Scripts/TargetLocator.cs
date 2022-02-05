using System.Linq;
using UnityEngine;

namespace RealmRush
{
    public class TargetLocator : MonoBehaviour
    {
        [SerializeField] private Transform weaponToRotate;
        [SerializeField] private float weaponRange = 15f;
        [SerializeField] private Transform target;
        private ParticleSystem _particleSystem;

        private bool InRange => Vector3.Distance(transform.position, target.position) <= weaponRange;

        private void Start()
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        private void Update()
        {
            FindClosestTarget();
            AimWeapon();
            Attack(InRange);
        }

        private void FindClosestTarget()
        {
            target = FindObjectsOfType<Enemy>()
                .OrderBy(x => Vector3.Distance(transform.position, x.transform.position))
                .First().transform;
        }

        private void AimWeapon()
        {
            if (!target) return;
            weaponToRotate.LookAt(target);
        }

        private void Attack(bool isActive)
        {
            var emission = _particleSystem.emission;
            emission.enabled = isActive;
        }
    }
}
