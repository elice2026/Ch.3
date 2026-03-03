using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketDamage : MonoBehaviour
{
    private string AsteroidTag = "ASTEROID";
    public Image HpBar;
    private int hp = 0;
    private int hpInit = 100;
    private int damage = 5;
    void Start()
    {
        hp = hpInit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(AsteroidTag))
        {
            Debug.Log("충돌 감지 - Rocket");
            CameraShake.Instance.TurnOn();
            hp -= damage;
            hp = Mathf.Clamp(hp, 0, hpInit);
            HpBar.fillAmount = (float)hp / hpInit;

            if(hp <= 0)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
