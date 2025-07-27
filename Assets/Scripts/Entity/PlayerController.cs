using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpHeight = 1.5f;
    public float jumpDuration = 0.4f;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private Vector2 moveInput;
    private bool isJumping = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // 대각선 방지
        if (x != 0 && y != 0)
        {
            y = 0;
        }

        moveInput = new Vector2(x, y);

        _animator.SetFloat("MoveX", moveInput.x);
        _animator.SetFloat("MoveY", moveInput.y);
        _animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // 애니메이션 속도 조절
        _animator.speed = moveInput.sqrMagnitude > 0 ? 1 : 0;

        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    void FixedUpdate()
    {
        if (_rigidbody != null && !isJumping)
        {
            _rigidbody.MovePosition(_rigidbody.position + moveInput.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }

    IEnumerator JumpRoutine()
    {
        isJumping = true;

        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 jumpPeak = startPos + new Vector3(0, jumpHeight, 0);

        // 상승
        while (elapsed < jumpDuration / 2f)
        {
            transform.position = Vector3.Lerp(startPos, jumpPeak, elapsed / (jumpDuration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = jumpPeak;
        elapsed = 0f;

        // 하강
        while (elapsed < jumpDuration / 2f)
        {
            transform.position = Vector3.Lerp(jumpPeak, startPos, elapsed / (jumpDuration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = startPos;
        isJumping = false;
    }
}
