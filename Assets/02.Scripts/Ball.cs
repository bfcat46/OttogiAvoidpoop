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
        if (collision.gameObject.CompareTag("Ground")) // �浹�� ��ü�� �ٴ��̶��
        {
            Debug.Log("�ٴ� �浹");
            Animator animator = GetComponent<Animator>();
            animator.enabled = false; // �ִϸ����� ��Ȱ��ȭ

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // ���� ��ȣ�ۿ� ��Ȱ��ȭ
            }

            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = false; // �ݶ��̴� ��Ȱ��ȭ
            }

            Invoke("DestroyBall", 3f); // ����� �浹�ϸ� 3�� �� ����
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