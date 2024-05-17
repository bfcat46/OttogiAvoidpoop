using UnityEngine;

public class Ball : MonoBehaviour
{
    //private float speed = 0.05f;

    //public int type;

    private void Start()
    {
        var x = Random.Range(-3.0f, 3.0f);
        const float y = 10.0f;
        transform.position = new Vector2(x, y);
    }

    void Update()
    {
        //transform.position += Vector3.down * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // 충돌한 객체가 바닥이라면
        {
            Debug.Log("바닥 충돌");
            Animator animator = GetComponent<Animator>();
            animator.enabled = false; // 애니메이터 비활성화

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // 물리 상호작용 비활성화
            }

            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false; // 콜라이더 비활성화
            }

            Invoke("DestroyBall", 3f); // 지면과 충돌하면 3초 후 삭제
        }

        //if (!collision.gameObject.CompareTag("Ground")) return;
        //var animator = GetComponent<Animator>();
        //animator.enabled = false;
        //Invoke(nameof(DestroyBall), 3f);

    }


    private void DestroyBall()
    {
        Destroy(gameObject);
    }

}