using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rbody2D;
    public GameObject Effect;
    public float Speed = 70f;
	void Start ()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        rbody2D.AddForce(transform.right * Speed);
        Destroy(gameObject, 2.5f);
	}
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.gameObject.tag =="Asteroid")
        {
            GameObject eff = Instantiate(Effect, Other.transform.position, 
                                                          Quaternion.identity);
            Destroy(eff, 0.5f);
            Destroy(Other.gameObject, 0.1f);
            Destroy(gameObject,0.1f);
        }
    }
}
