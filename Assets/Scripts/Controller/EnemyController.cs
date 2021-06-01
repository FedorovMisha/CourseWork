using System;
using System.Collections;
using System.Collections.Generic;
using Abstraction;
using Implementation;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controller
{
    public class EnemyController : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] public GameObject trackObj;

        [FormerlySerializedAs("enemy")] public GameObject enemyObj;

        private ITracker _playerTracker;

        private ITracker _enemyTracker;
        
        private IEnemy _enemy = default;

        [FormerlySerializedAs("LayerMask")] [SerializeField] private LayerMask layerMask;

        [SerializeField]private float detectRadius;
        
        [SerializeField] private GameObject enemyTracker;
        public IEnemy Enemy
        {

            set
            {
                if (_enemy == null && value != null)
                    _enemy = value;
            }
        }

        #endregion


        private void Start()
        {
            trackObj = Scene.UnitTracker;

            var track = trackObj.GetComponent<ITracker>();
            var component = enemyObj.GetComponent<IEnemy>();
            Enemy = component;
            var trackComp = enemyTracker.GetComponent<ITracker>();
            
            if (trackObj == null)
                throw new Exception();

            _playerTracker = track;
            _enemyTracker = trackComp;

            _enemy.Focus(_playerTracker.GetTrackedObject());
        }


        private void FixedUpdate()
        {
            _enemy.PlayerPosition = _playerTracker.GetPosition();
            var detect =  DetectPlayer();
            // Debug.Log(_playerTracker.GetTrackedObject().name + " Enemy: " + gameObject.name);
            if (_enemy.CanGoForward() && !detect)
                    _enemy.Traffic(_playerTracker.GetPosition());
            else
            {
                _enemy.Traffic(_enemyTracker.GetPosition());
            }
            // Debug.Log(_enemy.CanGoForward());
            // Debug.Log($"E = {_enemyTracker.GetPosition()} = P {_playerTracker.GetPosition()}");
            // Debug.Log(DetectPlayer());
            if (!_enemy.CanGoForward())
                _enemy.Jump();
            
                
            if (detect)
            {
                _enemy.Attack();
            }
        }


        private bool DetectPlayer()
        {
            var result = false;
            Debug.Log("Detect player");
            RaycastHit2D hit = Physics2D.Raycast(_enemyTracker.GetPosition(), _playerTracker.GetPosition() - _enemyTracker.GetPosition() , detectRadius, layerMask: layerMask);
            Debug.DrawRay(_enemyTracker.GetPosition(), Vector3.ClampMagnitude(_playerTracker.GetPosition() - _enemyTracker.GetPosition(), 5f), Color.red);
            if (hit)
            {
                result = true;
                if (_enemyTracker.GetTrackedObject().name.Contains("FlyingEnemy"))
                {
                    Debug.Log("Player detected");
                    result = Mathf.Abs(_playerTracker.GetPosition().x - _enemyTracker.GetPosition().x) < 1f;
                }
                // Debug.Log("Hit something:" + hit.transform.name);
            }

            return result;
        }

        private IEnumerator StopedReaction()
        {
            while (enemyObj != null)
            {
                var oldPos = _enemyTracker.GetPosition();
                yield return new WaitForSeconds(0.5f);
                if (Math.Abs(Mathf.Abs(oldPos.x + 0.1f) - Mathf.Abs(_enemyTracker.GetPosition().x)) < 0.2f)
                    _enemy.Jump();
            }
        }
    }
}
