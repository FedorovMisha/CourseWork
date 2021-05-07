using System.Collections;
using Abstraction;
using UnityEngine;

public class Bullet : MonoBehaviour, IStaticUnit
{
    public float speedBullet = 7f;
    public float startTimeBltShots;
    private float timeBltShots;

    private void Start()
    {
        StartCoroutine(KillDuration());
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speedBullet * Time.deltaTime);
    }


    private IEnumerator KillDuration()
    {
        yield return new WaitForSeconds(5f);
        Kill();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void ToInteract(IAliveUnit unit)
    {
        unit.GetDamage(20f);
        Kill();
    }
}