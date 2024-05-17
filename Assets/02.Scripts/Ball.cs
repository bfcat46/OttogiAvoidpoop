using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private float speed = 0.05f;

    //public int type;

    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = 10.0f;
        transform.position = new Vector2(x, y);
    }

    void Update()
    {
        //transform.position += Vector3.down * speed; // 이동방법1
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 충돌한 객체가 바닥이라면
        {
            Debug.Log("바닥 충돌");
            Animator animator = GetComponent<Animator>();
            animator.enabled = false; // 애니메이터 비활성화
            Invoke("DestroyBall", 3f); // 지면과 충돌하면 3초 후 삭제
        }
        else if (collision.gameObject.CompareTag("Player")) // 충돌한 객체가 플레이어라면
        {
            Debug.Log("플레이어 충돌");
            Time.timeScale = 0.0f; // 멈추고
            GameManager.Instance.GameOver(); // 게임오버 패널 호출
        }
    }


    private void DestroyBall()
    {
        Destroy(gameObject);
    }

}
