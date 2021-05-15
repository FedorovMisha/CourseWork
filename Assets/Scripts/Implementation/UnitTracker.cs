using System;
using Abstraction;
using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation
{
    public class UnitTracker : MonoBehaviour, ITracker
    {

        [FormerlySerializedAs("player")] [SerializeField]private GameObject unit;

        public void Awake()
        {
            
        }

        public Vector3 GetPosition()
        {
            return unit.transform.position;
        }

        public GameObject GetTrackedObject()
        {
            return unit;
        }
    }
}