using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글톤 인스턴스
    public Text scoreText; // 점수 표시 UI 텍스트
    public GameObject asteroidPrefab; // 생성할 에스터로이드 프리팹
    private float timePrev = 0f; // 마지막 생성 시간 기록
    private float score = 0;
    private void Awake()
    {
        Instance = this; // 싱글톤 인스턴스 초기화
        timePrev = Time.time; // 현재시간으로 초기화
    }
    void Update()
    {
        //현재시 - 과거시 = 경과시간
        if ((Time.time - timePrev) >= 2.0f)
        {
            SpawnAsteroid();
        }
        score += Time.deltaTime * 10f; // 시간에 따라 점수 증가
        scoreText.text = $"Score : {Mathf.FloorToInt(score).ToString()}"; // UI 텍스트 업데이트
    }

    private void SpawnAsteroid()
    {
        float RandomYPos = Random.Range(-3f, 3.8f);
        float _Scale = Random.Range(0.3f, 1.0f);
        asteroidPrefab.transform.localScale = Vector3.one * _Scale; // 프리팹의 스케일 조정
                                                                    //2초마다 에스터로이드 생성
        Instantiate(asteroidPrefab, new Vector3(12f, RandomYPos, 0f), Quaternion.identity);
        timePrev = Time.time; //생성 후 현재시간으로 갱신
    }
}