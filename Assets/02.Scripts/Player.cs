using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public float MaxSpeed;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private bool isShieldActive;
    private float shieldDuration = 10.0f;
    private GameObject shield;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.freezeRotation = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        shield = transform.Find("Shield").gameObject;
    }

    private void Start()
    {
        shield.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            ActivateShield();
        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isShieldActive)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    private void ActivateShield()
    {
        if (isShieldActive) return;
        isShieldActive = true;
        shield.SetActive(true);
        StartCoroutine(ShieldTimer());
    }

    private IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(shieldDuration);
        isShieldActive = false;
        shield.SetActive(false);
    }


    private void Update()
    {
        //Stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            _rigid.velocity = new Vector2(0.5f * _rigid.velocity.normalized.x, _rigid.velocity.y);
        }

        //Direction Sprite
        if (Input.GetKeyDown(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
        }

        _animator.SetBool(IsWalking, !(Mathf.Abs(_rigid.velocity.x) < 0.2));
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        _rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (_rigid.velocity.x > MaxSpeed)
        {
            _rigid.velocity = new Vector2(MaxSpeed, _rigid.velocity.y);
        }
        else if (_rigid.velocity.x < MaxSpeed * -1)
        {
            _rigid.velocity = new Vector2(MaxSpeed * -1, _rigid.velocity.y);
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        GameManager.Instance.GameOver();
    }
    */
}