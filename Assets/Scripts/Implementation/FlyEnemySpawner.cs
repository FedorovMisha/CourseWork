using System;
using System.Collections;
using Abstraction;
using Controller;
using UnityEngine;

namespace Implementation
{
    public class FlyEnemySpawner : MonoBehaviour
    {
        public GameObject _flyEnemyPrefab;

        private GameObject _spawnObj;

        // public GameObject _tracker;
        
        
        public void Start()
        {
            // StartCoroutine(Spawn());
        }

        private void FixedUpdate()
        {
            if (_spawnObj == null)
            {
                var obj = Instantiate(_flyEnemyPrefab);
                _spawnObj = obj;
                // obj.GetComponent<EnemyController>().trackObj = _tracker;
                obj.transform.position = this.gameObject.transform.position;
            }  
        }

        // public IEnumerator Spawn()
        // {
        //     while (true)
        //     {
        //     }
        // }
    }
}