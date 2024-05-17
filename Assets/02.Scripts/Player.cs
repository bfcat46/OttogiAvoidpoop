using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;

    public float maxSpeed; // 최대 속력 변수

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed) // 오른쪽으로 이동 (+) , 최대 속력을 넘으면
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x < maxSpeed*(-1)) // 왼쪽으로 이동 (-)
        {
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y); // y 값은 점프의 영향이므로 0으로 제한을 두면 안됨
        }

    }
}
