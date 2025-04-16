using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _displacementMultiplier = 0.15f;
    private float _zPosition = -10;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cameraDisplacement = (mousePosition - _playerTransform.position) * _displacementMultiplier;


        Vector3 finalCameraPosition = _playerTransform.position + cameraDisplacement;
        finalCameraPosition.z = _zPosition;
        transform.position = finalCameraPosition;
    }
}