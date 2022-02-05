using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RealmRush
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float spawnTimer = 1f;
        [SerializeField] private float waveTimer = 2f;
        [SerializeField] private int poolSize = 5;

        private GameObject[] EnemyPool { get; set; }

        private void Awake()
        {
            PopulatePool();
        }

        private void Start()
        {
            if (!enemyPrefab) return;
            StartCoroutine(EnableObjectInPool());
        }

        private void PopulatePool()
        {
            EnemyPool = new GameObject[poolSize];
            for (var i = 0; i < poolSize; i++)
            {
                EnemyPool[i] = Instantiate(enemyPrefab, gameObject.transform);
                EnemyPool[i].SetActive(false);
            }
        }

        private IEnumerator EnableObjectInPool()
        {
            while (true)
            {
                foreach (var enemy in EnemyPool.Where(x => !x.activeInHierarchy))
                {
                    enemy.SetActive(true);
                    yield return new WaitForSeconds(spawnTimer);
                }
                yield return new WaitForSeconds(waveTimer);
            }
        }
    }
}
