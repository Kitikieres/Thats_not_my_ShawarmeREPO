using UnityEngine;

public class SimpleParallax : MonoBehaviour
{
    [Header("Intensidad del efecto")]
    [Range(0f, 1f)]
    public float parallaxStrength = 0.3f;

    private Transform cameraTransform;
    private Vector3 startPos;
    private Vector3 cameraStartPos;

    void Start()
    {
        cameraTransform = Camera.main.transform;

        startPos = transform.position;
        cameraStartPos = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 cameraDelta = cameraTransform.position - cameraStartPos;

        transform.position = startPos + new Vector3(
            cameraDelta.x * parallaxStrength,
            cameraDelta.y * parallaxStrength,
            0
        );
    }
}
