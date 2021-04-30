using UnityEngine;
using Abstraction;

[System.Serializable] public class Player: IAliveUnit
{
    private const int MAXHealth = 101;
    public float Health{ get; set; } = 100;
    public float jumpForce;
    public float speed; 
    /*Джойстики*/
    public Joystick joystickRun;
    public Joystick joystickShooting;

    /*Прыжок игрока*/
    public LayerMask whatIsGround;
    public Transform groundCheck;
    float checkRadius = 0.1f;
    bool isGrounded;

     /*Стрельба*/
    public GameObject bullet;
    public Transform weaponPose; // Оружие
    public Transform gunPoint;
   
    float curTimeout;
    
    [HideInInspector] public Rigidbody2D rb;
   // [HideInInspector] public Animator anim; 
    float rotateGun;
    float horizontalMove = 0f, verticallMove = 0f;

    public void Traffic()
    {
        horizontalMove = joystickRun.Horizontal;
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

         Flip(joystickRun);
            if (horizontalMove == 0)
            {
              //  anim.SetBool("IsRunning", false);
            }
            else
            {
               // anim.SetBool("IsRunning", true);
            }  
    }

    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(isGrounded == true)
        {
        verticallMove = joystickRun.Vertical;
        rb.velocity = Vector2.up*jumpForce;
        }
    }

    public void Attack()
    {
      
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
            if (Health <= 0)
            {
                Kill();
            }
            Debug.Log("Test unit: " + Health);
    }

    public void RestoreHealth(float restoredHealth)
    {
        if(Health != 100)
        {
        Health += restoredHealth;
        }
        Health %= MAXHealth;
        Debug.Log("Health: " + Health);
    }

    public void Kill()
    {
        
    }


    void Flip(Joystick joystick) //Поворот игрока
    { 
        if (joystick.Horizontal > 0)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (joystick.Horizontal < 0)
        {
            rb.transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
    }

    public void WeaponRotate() //Поворот оружия по оси
    {
        if (joystickShooting.Horizontal > 0)
            {
                rotateGun = Mathf.Atan2(joystickShooting.Vertical, joystickShooting.Horizontal) * Mathf.Rad2Deg;
                weaponPose.rotation = Quaternion.Euler(0, 0, rotateGun);
            }
            if (joystickShooting.Horizontal < 0)
            {
                rotateGun = Mathf.Atan2(joystickShooting.Vertical, -joystickShooting.Horizontal) * Mathf.Rad2Deg;
                weaponPose.rotation = Quaternion.Euler(0, 180, rotateGun);
            }

            Flip(joystickShooting);
            if ( joystickShooting.Horizontal == 0 && joystickShooting.Vertical == 0)
            {
                weaponPose.localRotation = Quaternion.Euler(0, 0, 0);
            }
    }

}
