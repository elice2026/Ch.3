using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float Speed = 13f;
    public GameObject Effect;
    void Start ()
    { 
       
    }
	
	void Update ()
    {
        
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
        if(transform.localPosition.x < -25f)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("충돌");
            GameObject eff = 
                Instantiate(Effect, Other.transform.position, Quaternion.identity);
            Destroy(eff, 0.5f);
            G_Manger.gManger.TurnOn();
        }
    }
   
}
