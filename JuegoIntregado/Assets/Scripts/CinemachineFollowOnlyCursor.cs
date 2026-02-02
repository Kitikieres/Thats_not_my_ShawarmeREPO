using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CinemachineFollowOnlyCursor : MonoBehaviour
{
    public CinemachineCamera virtualCamera;

    [Range(0f, 1f)]
    public float smoothSpeed = 0.15f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        if (virtualCamera == null)
            virtualCamera = GetComponent<CinemachineCamera>();

        GameObject followTarget = new GameObject("CursorFollowTarget");
        virtualCamera.Follow = followTarget.transform;
    }

    void Update()
    {
        
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(
            new Vector3(mouseScreenPos.x, mouseScreenPos.y,
            Mathf.Abs(mainCamera.transform.position.z))
        );

        Transform follow = virtualCamera.Follow;

        follow.position = Vector3.Lerp(
            follow.position,
            new Vector3(mouseWorldPos.x, mouseWorldPos.y, follow.position.z),
            smoothSpeed
        );
    }
}
