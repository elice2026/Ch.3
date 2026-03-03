using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCTRL : MonoBehaviour
{
    public float Speed = 5f;
    private Transform tr;
    public Transform firePos;
    public GameObject bulletPrefab;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        #region if문을 통한 플랫폼 구분
        //현재 플랫폼이 어떤 플랫폼인지 확인
        //if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //tr.Translate(Vector3.up * Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        ////W,S 키 입력에 따라 로켓이 위아래로 움직이게 함
        //tr.Translate(Vector3.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime);
        ////A,D 키 입력에 따라 로켓이 좌우로 움직이게 함
        //}
        //else if (Application.platform == RuntimePlatform.Android)
        //{

        //}
        //else if (Application.platform == RuntimePlatform.IPhonePlayer)
        //{

        //}

        //위의 구분은 플랫폼별로 다른 입력 방식을 처리하기 위해서지만 요즘은 New Input System을 사용하게 된다면 플랫폼 구분없이 동일한 코드로 작성 가능
        #endregion

        #region switch문을 통한 플랫폼 구분
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                //윈도우 에디터일 때 처리할 내용

                tr.Translate(Vector3.up * Input.GetAxis("Vertical") * Speed * Time.deltaTime);
                //W,S 키 입력에 따라 로켓이 위아래로 움직이게 함
                tr.Translate(Vector3.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime);
                //A,D 키 입력에 따라 로켓이 좌우로 움직이게 함
                break;
            case RuntimePlatform.Android:
                //안드로이드일 때 처리할 내용
                MobileTouch();
                break;
            case RuntimePlatform.IPhonePlayer:
                //아이폰일 때 처리할 내용
                MobileTouch();
                break;
            default:
                //그 외 플랫폼일 때 처리할 내용
                break;
        }
        #endregion

        #region 로켓 이동시 카메라를 벗어나지 못하게 제한(초보용)
        // if (tr.position.x >= 7.4f)
        // {
        //     tr.position = new Vector3(7.4f, tr.position.y, tr.position.z);
        // }

        // else if (tr.position.x <= -7.4f)
        // {
        //     tr.position = new Vector3(-7.4f, tr.position.y, tr.position.z);
        // }

        // if (tr.position.y >= 4.4f)
        // {
        //     tr.position = new Vector3(tr.position.x, 4.4f, tr.position.z);
        // }

        // else if (tr.position.y <= -3.3f)
        // {
        //     tr.position = new Vector3(tr.position.x, -3.3f, tr.position.z);
        // }
        #endregion

        #region 로켓 이동시 카메라를 벗어나지 못하게 제한
        tr.position = new Vector3
        (
            Mathf.Clamp(tr.position.x, -7.4f, 7.4f),
            Mathf.Clamp(tr.position.y, -3.3f, 4.4f),
            tr.position.z
        );
        #endregion
    }

    private void MobileTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // 첫번째 터치정보 가져오기
            if (touch.phase == TouchPhase.Moved) // 터치가 이동중일 때
            {
                // 터치 유형이 이동중이라면
                // touch.deltaPosition : 이전 프레임에서 이번 프레임까지의 터치 이동량
                Vector2 deltaPos = touch.deltaPosition; //터치 이동량을 로켓 이동량으로 변환
                float sensitivity = 0.2f; // 민감도 조절 변수
                Vector3 moveDir = new Vector3(deltaPos.x, deltaPos.y, 0);
                tr.Translate(moveDir * sensitivity * Speed * Time.deltaTime);
            }
        }
    }

    public void Fire()
    {
        Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
    }
}
