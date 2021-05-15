using System;
using System.Collections;
using UnityEngine;

namespace Implementation
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject prefab;
        public float Duration { get; set; } = 10f;
        public void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        public void ChangePrefab(GameObject newPrefab)
        {
            Debug.Log("change prefab");
            
            if(newPrefab == null)
                return;
            
            prefab = newPrefab;
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                if (prefab != null)
                {
                    var enemy = Instantiate(prefab);
                    var spawnPosition = this.gameObject.transform.position;
                    spawnPosition.y += 10f;
                    enemy.gameObject.transform.position = spawnPosition;
                    yield return new WaitForSeconds(Duration);
                }
            }
        }
    }
}