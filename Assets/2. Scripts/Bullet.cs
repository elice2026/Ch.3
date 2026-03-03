using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed = 7f;    
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.right * speed);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
