using System;
using Abstraction;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Implementation
{
    public class HeartSpawner : MonoBehaviour, ISpawnSubscriber
    {
        [SerializeField] public GameObject prefab;
        [SerializeField] private Vector3 spawnPoint;
        [SerializeField]private GameObject _spawnObj = null;

        public void Start()
        {
            var position= this.gameObject.transform.position;
            
            spawnPoint = new Vector3(position.x,
                position.y + prefab.transform.localScale.y / 2,
                position.z);

        }

        public void FixedUpdate()
        {
            if (_spawnObj == null)
            {
                IsSpawned = false;
            }
        }

        public bool IsSpawned { get; set; } = false;

        public void UpdateSubscriber(Action action)
        {
            Spawn(action);
        }

        private void Spawn(Action action)
        {
            if (!IsSpawned)
            {
                IsSpawned = true;
                var obj = Instantiate(prefab);
                var responsive = obj.GetComponent<IResponsive>();
                if (responsive != null)
                {
                    responsive.OnChange += IsDestroy;
                    responsive.OnChange += action;
                }

                obj.transform.position = spawnPoint;
                _spawnObj = obj;
            }
        }

        private void IsDestroy()
        {
            IsSpawned = false;
            _spawnObj = null;
        }
    }
}
