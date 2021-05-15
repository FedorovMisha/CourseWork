using System;
using UnityEngine;

namespace Implementation
{
    public class Zone : MonoBehaviour
    {
        public GameObject prefab;


        private void OnTriggerEnter2D(Collider2D other)
        {
            var spawner = other.gameObject.GetComponent<EnemySpawner>();
            // Debug.Log(other.name);
            
            if (spawner != null)
            {
                Debug.Log(spawner.name);
                
                spawner.ChangePrefab(prefab);
            }
        }
    }
}