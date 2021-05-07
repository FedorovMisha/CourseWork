using Abstraction;
using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation
{
    public class UnitTracker : MonoBehaviour, ITracker
    {
        [FormerlySerializedAs("player")] [SerializeField]private GameObject unit;
        
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