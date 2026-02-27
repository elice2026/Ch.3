using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_Manger : MonoBehaviour
{
    public GameObject AsteroidObj;
    private float TimePrev;
    Vector3 PosCamera;
    float HitBeginTime;
    public static G_Manger gManger;
    private bool IsHit = false;
	void Start ()
    {
        TimePrev = Time.time;
        gManger = this;
        IsHit = false;
    }
	void Update ()
    {
        if (Time.time - TimePrev > 2.0f)
        {
            SpawnAsteroid();
            TimePrev = Time.time;
        }
		if(IsHit)
        {
            CameraShake();
            if(Time.time - HitBeginTime > 0.3f)
            {
                IsHit = false;
                Camera.main.transform.position = PosCamera;
            }
        }
	}
    void SpawnAsteroid()
    {
        float RandomYpos = Random.Range(-6f, 6f);
        float _Scale = Random.Range(1, 4);
        AsteroidObj.transform.localScale = Vector3.one * _Scale;   
        Instantiate(AsteroidObj, new Vector3(17f, RandomYpos, 0f), Quaternion.identity);
    }
   public void TurnOn()
    {
        IsHit = true;
        PosCamera = Camera.main.transform.position;
        HitBeginTime = Time.time;
    }
    void CameraShake()
    {
        float x = Random.Range(-0.1f, 0.1f);
        float y = Random.Range(-0.1f, 0.1f);
        Camera.main.transform.position += new Vector3(x, y,0f);
    }
}
