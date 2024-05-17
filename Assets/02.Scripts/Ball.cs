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
        //transform.position += Vector3.down * speed; // �̵����1
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // �浹�� ��ü�� �ٴ��̶��
        {
            Debug.Log("�ٴ� �浹");
            Animator animator = GetComponent<Animator>();
            animator.enabled = false; // �ִϸ����� ��Ȱ��ȭ
            Invoke("DestroyBall", 3f); // ����� �浹�ϸ� 3�� �� ����
        }
        else if (collision.gameObject.CompareTag("Player")) // �浹�� ��ü�� �÷��̾���
        {
            Debug.Log("�÷��̾� �浹");
            Time.timeScale = 0.0f; // ���߰�
            GameManager.Instance.GameOver(); // ���ӿ��� �г� ȣ��
        }
    }


    private void DestroyBall()
    {
        Destroy(gameObject);
    }

}
