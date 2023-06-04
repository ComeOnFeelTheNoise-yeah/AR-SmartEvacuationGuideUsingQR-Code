using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // 큐알 오브젝트의 Transform 컴포넌트를 참조하기 위한 변수
    public Transform targetCube;

    // Arrow의 회전 속도를 조절하는 변수
    public float rotationSpeed = 5f;

    void Update()
    {
        // 사용자가 큐알을 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {
            // Arrow 객체를 큐알을 향하도록 회전시킴
            RotateTowardsTarget();
        }
    }

    void RotateTowardsTarget()
    {
        // Arrow의 위치에서 큐알까지의 방향 벡터를 계산
        Vector3 direction = targetCube.position - transform.position;
        direction.y = 0; // 만약 화살표가 y축을 따라 회전하지 않도록 하려면 이 줄을 제거하거나 주석 처리하세요.

        // 방향 벡터를 회전값으로 변환
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Arrow의 회전을 부드럽게 보간
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
