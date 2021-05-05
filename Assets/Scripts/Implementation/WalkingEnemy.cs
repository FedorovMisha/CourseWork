﻿using System;
using Abstraction;
using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class WalkingEnemy : MonoBehaviour, IEnemy
    {

        #region Fields

        private bool _isReload = false;

        private int _bulletCapacity = 10;

        private float _reloadTime = 5f;

        private float _shootDuration = 1f;
        
        [SerializeField] private float enemySpeed = 10f;

        [SerializeField] private float deltaSpeed = 0.1f;
        
        private float _health = 100f;

        [SerializeField] private GameObject _bulletPrefab;
        
        private Vector2 _movementVector;
        private Vector2 CurrentPosition => this.transform.position;

        private Rigidbody2D _enemyRigidbody;

        private Vector2 direction;

        public float jumpForce = 10f;
        
        [FormerlySerializedAs("layerMask")] [SerializeField] private LayerMask layerMask;
        
        [FormerlySerializedAs("GroundCheck")] [SerializeField] private Transform groundCheck;

        [SerializeField] private Transform forwardCheck;
        #endregion

        private void Start()
        {
            _enemyRigidbody = GetComponent<Rigidbody2D>();
            direction = Vector2.right * deltaSpeed;
        }

        public void Kill()
        {
            Destroy(this.gameObject);
        }

        public void Traffic()
        {
            // Debug.Log("Move");
            _movementVector = CurrentPosition;
            direction.y = _enemyRigidbody.velocity.y;
            var moveDir = direction;
            moveDir.x = moveDir.x * enemySpeed;
            var oldJumpForce = jumpForce;
            _enemyRigidbody.velocity = moveDir;

        }

        public void Traffic(Vector3 to)
        {
            if (to.x < CurrentPosition.x)
            {
                direction = Vector2.left * deltaSpeed;
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (to.x > CurrentPosition.x)
            {
                direction = Vector2.right * deltaSpeed;
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                direction = Vector2.zero;
            }

            Traffic();
        }

        public void Jump()
        {
            if (CanJump())
            {
                var jumpDir = Vector2.up * jumpForce;
                jumpDir.x = _enemyRigidbody.velocity.x;
                _enemyRigidbody.velocity = jumpDir;
            }
        }

        public void Attack()
        {
            if (!_isReload)
            {
                if (_shootDuration > 0)
                {
                    _shootDuration -= Time.deltaTime;
                    return;
                }

                _shootDuration = 1f;
                var bullet = Instantiate(_bulletPrefab);

                if (bullet != null)
                {
                    bullet.transform.rotation = transform.rotation;

                    bullet.transform.position = transform.position;
                }

                _bulletCapacity -= 1;
            }
            else
            {
                Reload();
            }
        }

        public void GetDamage(float damage)
        {
            Debug.Log("Enemy get damage");
            _health -= damage;
            if(_health <= 0)
                Kill();
        }

        public void RestoreHealth(float restoredHealth)
        {
            Debug.Log("enemy");
        }

        public bool CanGoForward()
        {
            return !Physics2D.OverlapCircle(forwardCheck.position,0.01f,layerMask);
        }

        public bool CanJump()
        {
            return Physics2D.OverlapCircle(groundCheck.position,0.4f,layerMask);
        }


        private void Reload()
        {
            if (_reloadTime > 0)
            {
                _reloadTime -= Time.deltaTime; 
                return;
            }
            _isReload = true;
            _reloadTime = 5f;
            _bulletCapacity = 10;
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            var component = other.gameObject.GetComponent<IStaticUnit>();
            
            
            if(component != null && component is Bullet)
                component.ToInteract(this);
        }
        

        private void OnTriggerEnter2D(Collider2D other)
        {
            var component = other.gameObject.GetComponent<IStaticUnit>();
            
            Debug.Log(component is Bullet);
            
            if(component != null && component is Bullet)
                component.ToInteract(this);
        }
    }
}