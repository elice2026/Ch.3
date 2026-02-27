using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteRoidMove : MonoBehaviour
{
    public float speed = 0f;
    [Header("사운드 효과")]
    public AudioSource source;
    public AudioClip hitClip;
    [Header("이펙트")]
    public GameObject expEffect; // Explosion Effect Prefab
    
    private Transform tr;
    private string PlayerTag = "Player";
    void Start()
    {
        speed = Random.Range(8f, 12f);
        // 스피드 값을 8~12 사이의 랜덤 값으로 설정
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.left * speed * Time.deltaTime);
        // 운석이 아래 방향으로 일정 속도로 움직이게 함

        if (tr.position.x < -12f)
        {
            Destroy(gameObject);
            // 운석이 화면 밖으로 나가면 오브젝트 삭제
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PlayerTag))
        {
            Destroy(gameObject, 0.5f);
            source.PlayOneShot(hitClip, 1.0f);
            var eff = Instantiate(expEffect, other.transform.position, Quaternion.identity);

            Destroy(eff, 1.5f);

        }
    }
}
