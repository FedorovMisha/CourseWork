using System;
using Abstraction;
using UnityEngine;

using Implementation;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private float timeBltShots;
    public float startTimeBltShots;


    [SerializeField] Player player = new Player();

    private void Start()
    {
        player.rb = GetComponent<Rigidbody2D>();
       // player.anim = GetComponent<Animator>();
    }

    private void Update()
    {
        player.Traffic();
        player.WeaponRotate();
        if (player.joystickRun.Vertical > .5f)
        {
        player.Jump();
        }

        if (timeBltShots <= 0)
        {
            if (player.joystickShooting.Horizontal > 0.3f || player.joystickShooting.Vertical > 0.3f )
            {
                Instantiate(player.bullet, player.gunPoint.position, player.weaponPose.transform.rotation);
                timeBltShots = startTimeBltShots;
            }
            
        }
        else
        {
            timeBltShots -= Time.deltaTime;
        }
    }

        

    public void OnCollisionEnter2D(Collision2D other)
        {
            var staticUnit = other.gameObject.GetComponent<IStaticUnit>();
            
            staticUnit?.ToInteract(player);
        }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var staticUnit = other.gameObject.GetComponent<IStaticUnit>();
            
        staticUnit?.ToInteract(player);
    }
}

