using System.Collections;
using System.Collections.Generic;
using Abstraction;
using UnityEngine;

public class FlyingMonster : MonoBehaviour, IEnemy
{

    #region Fields

    private Vector2 direction;

    private Rigidbody2D _enemyRigidbody;
    
    [SerializeField] private float enemySpeed = 10f;

    [SerializeField] private float deltaSpeed = 0.1f;
        
    private float _health = 100f;

    [SerializeField] public GameObject bombPrefab;
    
    private Vector2 _movementVector;
    private Vector2 CurrentPosition => this.transform.position;

    public float _duration = 5f;

    #endregion
    
    // Start is called before the first frame updated
    private void Start()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        direction = Vector2.right * deltaSpeed;
        // animationComponent = GetComponent<Animation>();
    }
    
    
    public void Kill()
    {
        Destroy(this.gameObject);
    }

    public void Traffic()
    {
        _movementVector = CurrentPosition;
        direction.y = _enemyRigidbody.velocity.y;
        var moveDir = direction;
        moveDir.x = moveDir.x * enemySpeed;
        // var oldJumpForce = jumpForce;
        _enemyRigidbody.velocity = moveDir;
    }

    public void Traffic(Vector3 to)
    {
        if (Mathf.Abs(Mathf.Abs(to.x) - Mathf.Abs(CurrentPosition.x)) < 0.2f)
        {
            direction = Vector2.zero;
        }
        else if (to.x < CurrentPosition.x)
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
        // Не может прыгать
    }

    public void Attack()
    {
        if (_duration >= 2f)
        {
            var bomb = Instantiate(bombPrefab);
            bomb.transform.position =
                new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 2f, this.gameObject.transform.position.z);
            
            
            
            bomb.GetComponent<Rigidbody2D>().AddForce(Vector2.down, ForceMode2D.Impulse);
            _duration = 0f;
            return;
        }

        _duration += Time.deltaTime;
    }

    public void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0) Kill();
    }

    public void RestoreHealth(float restoredHealth)
    {
        _health += restoredHealth;
        if (_health > 100f)
        {
            _health = 100f;
        }
    }


    public Vector3 PlayerPosition { get; set; }

    public void Focus(GameObject focusObj)
    {
        throw new System.NotImplementedException();
    }

    public bool CanGoForward()
    {
        return true;
    }

    public bool CanJump()
    {
        return false;
    }
}
