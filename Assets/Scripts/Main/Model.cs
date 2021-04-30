 using UnityEngine;


 namespace Model{
     
[System.Serializable] public class Player1
    {
        [HideInInspector] public Rigidbody2D rb;
        public Transform weaponPose; // Оружие
        public float speed; // Скорость
        [HideInInspector] public Animator anim; // Анимация
        private float rotateGun; // Поворот оружия
        public float JumpForce; // Прыжок игрока
        private float horizontalMove = 0f, verticallMove = 0f;
        
        /*Джойстики*/
        public Joystick joystickRun;
        public Joystick joystickShooting;

        /*Прыжок игрока*/
        private bool isGrounded;
        public Transform groundCheck;
        private float checkRadius = 0.2f;
        public LayerMask whatIsGround;

        /*Стрельба*/
        public Rigidbody2D bullet;
        public Transform gunPoint;
        public float speedBullet = 10;
        public float fireRate = 1;
        private float curTimeout;
        

        /*Процедуры*/

        //Поворот персонажа
        public void Run()
        {
            //weaponPose.transform.SetParent(rb.transform);
            horizontalMove = joystickRun.Horizontal;
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

            Flip(joystickRun);
            if (horizontalMove == 0)
            {
                anim.SetBool("IsRunning", false);
            }
            else
            {
                anim.SetBool("IsRunning", true);
            }  
        }

        //Поворот оружия
         public void WeaponRotate()
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


        private void Flip(Joystick joystick)
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
        public void Jump()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            if(isGrounded == true)
            {
            verticallMove = joystickRun.Vertical;
            rb.velocity = Vector2.up*JumpForce;
            }
        }   
        /*public void Shoot() 
        {
            curTimeout += Time.deltaTime;
            if(curTimeout > fireRate)
            {
                curTimeout = 0;
                Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
                clone.velocity = transform.TransformDirection(gunPoint.right * speed);
                clone.transform.right = gunPoint.right;
            }
        }*/
    }

       
    
 }
