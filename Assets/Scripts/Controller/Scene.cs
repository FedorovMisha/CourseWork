

using System;
using UnityEngine;

namespace Controller
{
    public class Scene : MonoBehaviour
    {

        public GameObject unitTracker;
        public static GameObject UnitTracker { get; set; }

        public void Awake()
        {
            UnitTracker = unitTracker;
        }
    }
}