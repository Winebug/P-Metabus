using UnityEngine;

public class FollowCamera2 : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;       // �ε巯�� �̵� �ӵ�
    public Vector2 minBounds;            // ī�޶� �ּ� �̵� ����
    public Vector2 maxBounds;            // ī�޶� �ִ� �̵� ����

    private Vector3 offset;              // �ʱ� �Ÿ� ������

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("FollowCamera2: target�� �Ҵ���� �ʾҽ��ϴ�.");
            return;
        }

        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // ��ǥ ��ġ = �÷��̾� ��ġ + ������
        Vector3 desiredPosition = target.position + offset;

        // ���� �ɱ�
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // �ε巴�� ����
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}
