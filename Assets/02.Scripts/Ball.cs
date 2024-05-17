using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private float speed = 0.05f;

    void Start()
    {
        float x = Random.Range(-3.0f, 3.0f);
        float y = 10.0f;
        transform.position = new Vector2(x, y);
    }

    void Update()
    {
        //transform.position += Vector3.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("바닥 충돌");
            Animator animator = GetComponent<Animator>();
            animator.enabled = false; // 애니메이터 비활성화
            Invoke("DestroyBall", 3f); // 지면과 충돌하면 3초 후 삭제
        }
    }


    private void DestroyBall()
    {
        Destroy(gameObject);
    }

}
