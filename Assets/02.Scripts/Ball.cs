using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _speed = 0.05f;

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
        if (!collision.gameObject.CompareTag("Ground")) return;
        var animator = GetComponent<Animator>();
        animator.enabled = false;
        Invoke(nameof(DestroyBall), 3f);
    }


    private void DestroyBall()
    {
        Destroy(gameObject);
    }

}