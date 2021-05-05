using System;
using Abstraction;
using UnityEngine;

namespace Implementation
{
    public class Health : MonoBehaviour, IStaticUnit, IResponsive
    {
        [SerializeField] private Sprite sprite;
        private float _restoreHealth = 10f;

        public float Freg  = 2;
        public float Amp = 0.25f;
        public float t = 0;
        public float offset = 0;
        public Vector2 StartPos;

        public void Start()
        {
            StartPos = transform.position;
        }

        public void FixedUpdate()
        {
             t = t +Time.deltaTime;
             offset = Amp* Mathf.Sin(t*Freg);

             transform.position = StartPos + new Vector2(0,offset);
        }

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