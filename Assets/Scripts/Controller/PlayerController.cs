using System;
using Abstraction;
using UnityEngine;

using Implementation;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Player player = new Player();

    private void FixedUpdate()
    {
        player.Traffic();
        player.WeaponRotate();
        if (player.joystickRun.Vertical > .5f)
        {
            player.Jump();
        }
        player.Attack();
    }
   
}

