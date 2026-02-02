using UnityEngine;
using Cinemachine;

public class CinemachineFollowOnlyCursor : MonoBehaviour
{
    [Header("Referencias")]
    public CinemachineVirtualCamera virtualCamera;

    [Header("Configuración")]
    [Range(0f, 1f)]
    public float smoothSpeed = 0.15f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if (virtualCamera == null)
            virtualCamera = GetComponent<CinemachineVirtualCamera>();

        // Creamos un objeto vacío para que la cámara lo siga
        GameObject followTarget = new GameObject("CursorFollowTarget");
        virtualCamera.Follow = followTarget.transform;
    }

    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Mathf.Abs(mainCamera.transform.position.z);

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        Transform follow = virtualCamera.Follow;

        // Movimiento suave hacia el cursor
        follow.position = Vector3.Lerp(
            follow.position,
            new Vector3(mouseWorldPos.x, mouseWorldPos.y, follow.position.z),
            smoothSpeed
        );
    }
}
