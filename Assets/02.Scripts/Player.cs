using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer; // ���� ��ȯ�� ���� ����

    public float maxSpeed; // �ִ� �ӷ� ����

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) // ���������� �̵� (+) , �ִ� �ӷ��� ������
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1)) // �������� �̵� (-)
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y); // y ���� ������ �����̹Ƿ� 0���� ������ �θ� �ȵ�
        }
    }
    void Update()
    {
        // ��ư���� ���� ���� ���� �ܹ����� Ű���� �Է��� FixedUpdate���� Update�� ���°� Ű���� �Է��� ������ Ȯ���� ������

        //Stop speed
        if(Input.GetButtonUp("Horizontal"))
        {
            // ��ư���� ���� ���� ��� 
            // normalized : ���� ũ�⸦ 1�� ���� ���� (�������� : ũ�Ⱑ 1�� ����)
            // ���ʹ� ����� ũ�⸦ ���ÿ� �����µ� ũ�� (- : ��, + : ��)�� �����ϱ� ���Ͽ� ��������(1,-1)�� ������ �� �� �ֵ��� �������͸� ����
            rigid.velocity = new Vector2(0.5f * rigid.velocity.normalized.x, rigid.velocity.y);

            //Direction Sprite
            if(Input.GetButton("Horizontal"))
            {
                // ����Ű �Է��� ������ ����
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // -1 (�����̸�, flipX true(üũ))
            }

        }
    }
}
