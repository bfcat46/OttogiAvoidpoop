using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer; // 방향 전환을 위한 변수

    public float maxSpeed; // 최대 속력 변수

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) // 오른쪽으로 이동 (+) , 최대 속력을 넘으면
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * (-1)) // 왼쪽으로 이동 (-)
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y); // y 값은 점프의 영향이므로 0으로 제한을 두면 안됨
        }
    }
    void Update()
    {
        // 버튼에서 손을 때는 등의 단발적인 키보드 입력은 FixedUpdate보다 Update에 쓰는게 키보드 입력이 누락될 확률이 낮아짐

        //Stop speed
        if(Input.GetButtonUp("Horizontal"))
        {
            // 버튼에서 손을 때는 경우 
            // normalized : 벡터 크기를 1로 만든 상태 (단위벡터 : 크기가 1인 벡터)
            // 벡터는 방향과 크기를 동시에 가지는데 크기 (- : 왼, + : 오)를 구별하기 위하여 단위벡터(1,-1)로 방향을 알 수 있도록 단위벡터를 곱함
            rigid.velocity = new Vector2(0.5f * rigid.velocity.normalized.x, rigid.velocity.y);

            //Direction Sprite
            if(Input.GetButton("Horizontal"))
            {
                // 방향키 입력이 들어오면 실행
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // -1 (왼쪽이면, flipX true(체크))
            }

        }
    }
}
