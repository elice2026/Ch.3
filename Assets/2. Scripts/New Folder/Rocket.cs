using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 5.0f;
    //private float halfHeight;
    //private float halfWidth;
    public JoyStick joystick;
    private Vector3 moveVector;
    private Transform tr;
    public Transform FirePos;
    public GameObject Bullet;
	void Start ()
    {
        //halfHeight = Screen.height * 0.5f;
        //halfWidth = Screen.width * 0.5f;
        tr = transform;
        moveVector = Vector3.zero;
	}
	void Update ()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            //if (Input.touchCount > 0)
            //{
            //    float deltaPosX = Input.GetTouch(0).position.x - halfWidth;
            //    float deltaPosY = Input.GetTouch(0).position.y - halfHeight;
            //    float Xpos = deltaPosX - transform.localPosition.x;
            //    float Ypos = deltaPosY - transform.localPosition.y;

            //    transform.Translate(Speed * Time.deltaTime * Xpos * 0.01f, Speed * Time.deltaTime * Ypos * 0.01f, 0f);
            //}
            HandleInput();
            Move();
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            transform.Translate(Vector3.up * Speed * Input.GetAxis("Vertical") * Time.deltaTime);
            transform.Translate(Vector3.right * Speed * Input.GetAxis("Horizontal") * Time.deltaTime);
            HandleInput();
            Move();
        }
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -14.5f, 14.5f),
            Mathf.Clamp(transform.localPosition.y, -6.5f, 6.5f), transform.position.z);
		
	}
    public void HandleInput()
    {
        moveVector = InputVector();
    }
    public Vector3 InputVector()
    {
        float h = joystick.GetHorizontalValue();
        float v = joystick.GetVerticalValue();
        Vector3 moveDir = new Vector3(h, v, 0).normalized;
        return moveDir;
    }
    public void Move()
    {
        transform.Translate(moveVector * Speed * Time.deltaTime);
    }
    public void Fire()
    {
        Instantiate(Bullet, FirePos.position, Quaternion.identity);

    }
}
