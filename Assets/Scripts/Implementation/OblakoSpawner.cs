using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;


public class OblakoSpawner : MonoBehaviour
{
    public GameObject Oblako;
    public Transform OblakoPoint;
    int YPoint = Random.Range(8,11);
    private float timeBltShots;
    public float startTimeBltShots;
    Vector3 point;
 
    private void Start()
    {
        point.x= OblakoPoint.position.x;
        point.y= OblakoPoint.position.y;
        point.z= OblakoPoint.position.z;
    }

    private void FixedUpdate()
    {
        
        if (timeBltShots <= 0)
        {
        int YPoint = Random.Range(6,9);
        point.y = YPoint;
        Instantiate(Oblako, point, OblakoPoint.transform.rotation);
        
         timeBltShots = startTimeBltShots;
        }
        else
        {
            timeBltShots -= Time.deltaTime;
        }


      
    }
}

