using UnityEngine;

public class Ball : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip Clip;
    public ParticleSystem BallParticle;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        var x = Random.Range(-3.0f, 3.0f);
        const float y = 10.0f;
        transform.position = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            GameManager.Instance.Score++;
            
            _audioSource.PlayOneShot(Clip);
            BallParticle.Play();

            var animator = GetComponent<Animator>();
            animator.enabled = false;

            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            var component = GetComponent<Collider2D>();
            if (component != null)
            {
                component.enabled = false; 
            }

            Invoke(nameof(DestroyBall), 3f);
        }

        else if (collision.gameObject.CompareTag("Player")) 
        {
            _audioSource.PlayOneShot(Clip);
        }
    }


    private void DestroyBall()
    {
        Destroy(gameObject);
    }

}