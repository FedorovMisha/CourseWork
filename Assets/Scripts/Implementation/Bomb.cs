using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abstraction;
using UnityEngine;

public class Bomb : MonoBehaviour, IStaticUnit
{
    [SerializeField] private readonly float _bombDamage = 40f;
    Rigidbody2D rb;

    public float speedRotate;

    [SerializeField]private float durationBeforeBoom;
    
    private readonly Dictionary<string, IAliveUnit> _radiusUnits = new Dictionary<string, IAliveUnit>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Boom());
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speedRotate, rb.velocity.y);
    }

    // Update is called once per frame

    public void Kill()
    {
        var parent = transform.parent;
        BombSpawner.BombsCount--;
        if(parent != null)
            Destroy(parent.gameObject);
        else
            Destroy(this.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var aliveUnit = other.GetComponent<IAliveUnit>();

        if (aliveUnit != null)
            _radiusUnits.Remove(aliveUnit.ToString());
    }

    public void ToInteract(IAliveUnit unit)
    {
        if (unit != null && !_radiusUnits.TryGetValue(unit.ToString(), out IAliveUnit unit1))
        {
            Debug.Log(unit.ToString());
            _radiusUnits.Add(unit.ToString(), unit);
        }
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(durationBeforeBoom);
        var itemsToDamage = _radiusUnits.Values.ToList();
        
        for (var i = 0; i < itemsToDamage.Count; i++)
        {
            itemsToDamage[i].GetDamage(_bombDamage);
        }

        var animObj = transform.parent ? transform.parent : transform;
        var timeToKill = animObj.GetComponent<Animation>().clip.length * 2f;
        animObj.GetComponent<Animation>().Play();
        
        yield return new WaitForSeconds(timeToKill);
        Kill();
    }
}
