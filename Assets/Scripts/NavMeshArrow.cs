using UnityEngine;
using UnityEngine.AI;

public class NavMeshArrow : MonoBehaviour
{
    [SerializeField]
    private Camera topDownCamera;
    [SerializeField]
    private GameObject navTargetObject;

    public GameObject arrowPrefab;    // Arrow 프리팹

    private NavMeshPath path;         // 경로 정보
    private LineRenderer lineRenderer;// 선 렌더러 컴포넌트
    private GameObject arrow;         // 생성된 Arrow 오브젝트

    private void Start()
    {
        path = new NavMeshPath();

        // LineRenderer 
        lineRenderer = transform.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.SetActive(false);
    }

    private void Update()
    {
        NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
        if (path.corners.Length > 1)
        {
            lineRenderer.positionCount = path.corners.Length;
            lineRenderer.SetPositions(path.corners);
            lineRenderer.enabled = true;
            arrow.SetActive(true);

            Vector3 targetPosition = path.corners[1];
            Vector3 direction = targetPosition - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            arrow.transform.position = transform.position;
            arrow.transform.rotation = lookRotation;
        }
        else
        {
            lineRenderer.enabled = false;
            arrow.SetActive(false);
        }
    }
}
