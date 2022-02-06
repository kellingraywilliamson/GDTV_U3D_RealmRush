using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    private int _currentHitPoints;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _currentHitPoints = maxHitPoints;
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        _currentHitPoints--;
        if (_currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            _enemy.RewardGold();
        }
    }
}
