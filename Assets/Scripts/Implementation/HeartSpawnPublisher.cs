using System;
using System.Collections.Generic;
using System.Linq;
using Abstraction;
using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation
{
    public class HeartSpawnPublisher : MonoBehaviour, IHeartSpawnPublisher
    {
        private List<ISpawnSubscriber> _subscribers = new List<ISpawnSubscriber>();
        
        [FormerlySerializedAs("Objects")] public List<GameObject> objects;

        public int MaxSpawnItems = 2;
        
        public void Start()
        {
            var sub = objects.Where(x => x.GetComponent<ISpawnSubscriber>() != null).Select(x => x.GetComponent<ISpawnSubscriber>()).ToList();
            _subscribers.AddRange(sub);

            if (MaxSpawnItems > _subscribers.Count)
            {
                MaxSpawnItems = Mathf.FloorToInt((float) _subscribers.Count / 2);
            }
            
            Notify();
        }

        public void Subscribe(ISpawnSubscriber spawnSubscriber)
        {
            _subscribers.Add(spawnSubscriber);
        }

        public void Unsubscribe(ISpawnSubscriber spawnSubscriber)
        {
            _subscribers.Remove(spawnSubscriber);
        }

        public void Notify()
        {
            foreach (var x in _subscribers)
            {
                if (_subscribers.Count(x => x.IsSpawned) >= MaxSpawnItems)
                {
                    break;
                }

                x.UpdateSubscriber(Notify);
            }

            _subscribers = _subscribers.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}