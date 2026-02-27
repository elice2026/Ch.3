using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGNearMove : MonoBehaviour
{
    public float speed = 3f;
    private Transform tr;
    private float width;
    private BoxCollider2D boxCollider;
    void Start()
    {
        tr = GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x; // 콜라이더 너비값 대입
        // 박스콜라이더 2D 사이즈 x 값을 width에 대입
    }

    void Update()
    {
        tr.Translate(Vector2.left * speed * Time.deltaTime);
        // 배경 화면이 왼쪽으로 일정 속도로 움직이게 함

        if (tr.position.x < -width)
        {
            Vector2 offset = new Vector2(width * 1f, 0);
            // 형변환 캐스팅
            tr.position = (Vector2)tr.position + offset;
            // 배경 화면이 자신의 너비의 2배 만큼 오른쪽으로 이동
            // 즉, 배경 화면이 왼쪽으로 화면 밖으로 나갔을 때 다시 오른쪽으로 이동시켜 무한 루프 효과를 냄
        }
    }
}
