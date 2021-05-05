using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float Freg  = 2;
    public float Amp = 0.25f;
    public float t = 0;
    public float offset = 0;
    public Vector2 StartPos;

    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        t = t +Time.deltaTime;
        offset = Amp* Mathf.Sin(t*Freg);

        transform.position = StartPos + new Vector2(0,offset);
    }
}
