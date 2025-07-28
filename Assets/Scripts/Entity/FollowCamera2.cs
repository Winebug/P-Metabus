using UnityEngine;

public class FollowCamera2 : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;       // 부드러운 이동 속도
    public Vector2 minBounds;            // 카메라 최소 이동 제한
    public Vector2 maxBounds;            // 카메라 최대 이동 제한

    private Vector3 offset;              // 초기 거리 오프셋

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("FollowCamera2: target이 할당되지 않았습니다.");
            return;
        }

        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 목표 위치 = 플레이어 위치 + 오프셋
        Vector3 desiredPosition = target.position + offset;

        // 제한 걸기
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // 부드럽게 따라감
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
