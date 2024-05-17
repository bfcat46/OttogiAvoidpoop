using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip Clip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        var x = Random.Range(-3.0f, 3.0f);
        const float y = 10.0f;
        transform.position = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // �浹�� ��ü�� �ٴ��̶��
        {
            _audioSource.PlayOneShot(Clip);
            var animator = GetComponent<Animator>();
            animator.enabled = false; // �ִϸ����� ��Ȱ��ȭ

            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // ���� ��ȣ�ۿ� ��Ȱ��ȭ
            }

            var component = GetComponent<Collider2D>();
            if (component != null)
            {
                component.enabled = false; // �ݶ��̴� ��Ȱ��ȭ
            }

            Invoke(nameof(DestroyBall), 3f); // ����� �浹�ϸ� 3�� �� ����
        }

        else if (collision.gameObject.CompareTag("Player")) // �浹�� ��ü�� �÷��̾���
        {
            _audioSource.PlayOneShot(Clip);
        }
    }


    private void DestroyBall()
    {
        Destroy(gameObject);
    }

}