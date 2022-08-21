using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGuage : MonoBehaviour
{
    public Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(250, 250 - player.velocity.magnitude * 10, 250));
    }
}
