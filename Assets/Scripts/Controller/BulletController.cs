using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speedBullet = 7f;
    private float timeBltShots;
    public float startTimeBltShots;

    private void Start()
    {
        StartCoroutine(Kill());
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right*speedBullet*Time.deltaTime);
    }


    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

}
