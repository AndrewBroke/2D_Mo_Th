using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionForce : MonoBehaviour
{
    public float value;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity != Vector2.zero)
        {
            rb.AddForce(-rb.velocity.normalized * value, ForceMode2D.Force);
        }
    }
}
