using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OblakoController : MonoBehaviour
{
    public float speedOblako;
      private void FixedUpdate()
    {
        transform.Translate(Vector2.right*speedOblako*Time.deltaTime);
        
        if(transform.position.x >115)
        {
           Destroy(this.gameObject); 
        }
    }
}
