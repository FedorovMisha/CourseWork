using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speedBullet = 7f;
    private float timeBltShots;
    public float startTimeBltShots;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right*speedBullet*Time.deltaTime);

    }


}
