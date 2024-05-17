using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;

    public float MaxSpeed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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

    private void Update()
    {
        //Stop speed
        if (!Input.GetButtonUp("Horizontal")) return;
        _rigid.velocity = new Vector2(0.5f * _rigid.velocity.normalized.x, _rigid.velocity.y);

        //Direction Sprite
        if(Input.GetButton("Horizontal"))
        {
            _spriteRenderer.flipX = Mathf.Approximately(Input.GetAxisRaw("Horizontal"), -1);
        }
    }
}
