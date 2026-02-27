using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance; // 싱글톤 인스턴스
    private Vector3 CameraPos; // 카메라의 원래 위치 저장
    public bool isShake = false; // 흔들기 여부를 나타내는 변수
    private float hitBeginTime; // 흔들기가 시작된 시간
    void Start()
    {
        Instance = this;
        
    }

    void Update()
    {
        if (isShake)
        {
            ShakeCamera();
        }
    }

    private void ShakeCamera()
    {
        float x = Random.Range(-0.1f, 0.1f); // x축 흔들림 범위
        float y = Random.Range(-0.1f, 0.1f); // y축 흔들림 범위
        Camera.main.transform.position = CameraPos + new Vector3(x, y, 0f);

        if (Time.time - hitBeginTime > 0.3f)
        {
            isShake = false; // 흔들기 종료
            Camera.main.transform.position = CameraPos; // 카메라를 원래 위치로 되돌림
        }
    }

    public void TurnOn()
    {
        isShake = true;
        CameraPos = Camera.main.transform.position; // 카메라의 원래 위치 저장
        hitBeginTime = Time.time; // 흔들기가 시작된 시간 저장
    }
}