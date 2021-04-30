using System;
using Abstraction;
using UnityEngine;

namespace Implementation
{
    public class Health : MonoBehaviour, IStaticUnit, IResponsive
    {
        [SerializeField] private Sprite sprite;
        private float _restoreHealth = 10f;

        public void ToInteract(IAliveUnit unit)
        {
            unit.RestoreHealth(_restoreHealth);
            Kill();
        }

        public void Kill()
        {
            OnChange.Invoke();
            Destroy(this.gameObject);
        }

        public Action OnChange { get; set; }
    }
}