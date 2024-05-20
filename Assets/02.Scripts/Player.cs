using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    public GameObject[] characters;

    public float MaxSpeed;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    [SerializeField]
    private GameObject GameOverModal;

    [SerializeField]
    private TextMeshProUGUI CurrentScoreTxt, BestScoreTxt;

    [SerializeField]
    private TextMeshProUGUI CurrentScoreResult, BestScoreResult;

    private void Start()
    {
        //characters[DataManager.instance.characterNum].SetActive(true);
    }

    private void Awake()
    {
        BestScoreTxt.text = GameManager.Instance.BestScore.ToString();
        GameOverModal.SetActive(false);
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.freezeRotation = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CurrentScoreTxt.text = GameManager.Instance.Score.ToString();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        GameOverModal.SetActive(true);
        var gameManager = GameManager.Instance;

        BestScoreTxt.text = gameManager.BestScore.ToString();
        if (gameManager.Score > gameManager.BestScore)
        {
            gameManager.BestScore = gameManager.Score;
            BestScoreTxt.text = gameManager.BestScore.ToString();
        }
        BestScoreResult.text = "최고 점수: " + gameManager.BestScore;
        CurrentScoreResult.text = "획득 점수: " + gameManager.Score;
        GameManager.GameOver();
    }
}