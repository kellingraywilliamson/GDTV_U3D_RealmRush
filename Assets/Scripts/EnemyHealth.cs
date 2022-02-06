using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;

    [Tooltip("The max-hit-point addition when the enemy dies.")]
    [SerializeField] [Range(1,5)] private int difficultyRamp = 1;

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
            maxHitPoints += difficultyRamp;
        }
    }
}
