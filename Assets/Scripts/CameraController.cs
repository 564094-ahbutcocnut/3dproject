using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _distanceFromTarget = 10f;

    private float sensitivity = 1000f;

    private float _yaw = 0f;
    private float _pitch = 0f;

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        Quaternion yawRotation  = Quaternion.Euler(_pitch, _yaw, 0f);

        RotateCamera(yawRotation);
    }

    public void HandleInput()
    {
        Vector2 inputDelta = Vector2.zero;

        if (InputDelta.GetMouseButton(0))
        {
            inputDelta = new Vector2(inputDelta.GetAxis("Mouse X"), inputDelta.GetAxis("Mouse Y"));
        }

        _yaw += inputDelta.x * sensitivity * Time.deltaTime;
        _pitch -= inputDelta.y * sensitivity * Time.deltaTime;

    }

    void RotateCamera(Quaternion rotation)
    {
        Vector3 positionOffset = rotation * new Vector3(0, 0, -_distanceFromTarget)
        transform.position = _target.position + positionOffset;
        transform.rotation = rotation;
    }
}
