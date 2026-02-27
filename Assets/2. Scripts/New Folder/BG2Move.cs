using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG2Move : MonoBehaviour {

    public float Speed = 0.2f;
    private Vector2 offset;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
        if (transform.localPosition.x <= -61f)
        {
            offset = Vector3.Lerp(new Vector3(-61f, transform.localPosition.y, 0), new Vector3(3f, transform.localPosition.y, 0f), Time.deltaTime * Speed);
            transform.localPosition = new Vector3(offset.x , transform.localPosition.y, transform.localPosition.z);
        }
            
	}
}
