using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class FnafStyleCamera : MonoBehaviour
{
    public CinemachineCamera virtualCamera;

    [Header("Zona muerta central")]
    [Range(0f, 0.5f)]
    public float deadZonePercent = 0.25f;

    [Header("Movimiento lateral")]
    public float moveSpeed = 8f;
    public float maxOffset = 6f;

    private Camera mainCamera;
    private Vector3 initialPosition;
    private Transform follow;

    void Start()
    {
        mainCamera = Camera.main;

        if (virtualCamera == null)
            virtualCamera = GetComponent<CinemachineCamera>();

        GameObject target = new GameObject("FnafCameraTarget");
        follow = target.transform;

        virtualCamera.Follow = follow;

        initialPosition = follow.position;
    }

    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        float screenW = Screen.width;
        float screenH = Screen.height;

        float centerX = screenW / 2f;
        float centerY = screenH / 2f;

        float deadX = screenW * deadZonePercent;
        float deadY = screenH * deadZonePercent;

        float offsetX = 0f;
        float offsetY = 0f;

        // ----- HORIZONTAL -----
        if (mousePos.x > centerX + deadX)
        {
            float t = (mousePos.x - (centerX + deadX)) / (centerX - deadX);
            offsetX = Mathf.Lerp(0, maxOffset, t);
        }
        else if (mousePos.x < centerX - deadX)
        {
            float t = ((centerX - deadX) - mousePos.x) / (centerX - deadX);
            offsetX = Mathf.Lerp(0, -maxOffset, t);
        }

        // ----- VERTICAL (opcional estilo FNAF) -----
        if (mousePos.y > centerY + deadY)
        {
            float t = (mousePos.y - (centerY + deadY)) / (centerY - deadY);
            offsetY = Mathf.Lerp(0, maxOffset, t);
        }
        else if (mousePos.y < centerY - deadY)
        {
            float t = ((centerY - deadY) - mousePos.y) / (centerY - deadY);
            offsetY = Mathf.Lerp(0, -maxOffset, t);
        }

        Vector3 targetPos = initialPosition + new Vector3(offsetX, offsetY, 0);

        follow.position = Vector3.Lerp(
            follow.position,
            targetPos,
            Time.deltaTime * moveSpeed
        );
    }
}
