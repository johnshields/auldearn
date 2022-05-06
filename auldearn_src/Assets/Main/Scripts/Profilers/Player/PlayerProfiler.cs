using UnityEngine;
using UnityEngine.InputSystem;

/*
 * PlayerProfiler
 * Script that controls the Player's movement and profile.
 */
public class PlayerProfiler : MonoBehaviour
{
    public float profileForce = 0.8f;
    public Camera playerCam;

    private Rigidbody _bodyPhysics;
    private KnightControls _controls;
    private Vector3 _forceDirection = Vector3.zero;
    private InputAction _move;

    private void Awake()
    {
        _bodyPhysics = GetComponent<Rigidbody>();
        _controls = new KnightControls();
    }

    private void FixedUpdate()
    {
        _forceDirection += _move.ReadValue<Vector2>().x * GetCameraRight(playerCam) * profileForce;
        _forceDirection += _move.ReadValue<Vector2>().y * GetCameraForward(playerCam) * profileForce;

        _bodyPhysics.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        LookAt();
    }

    private void OnEnable()
    {
        _move = _controls.Profiler.Move;
        _controls.Profiler.Enable();
    }

    private void OnDisable()
    {
        _controls.Profiler.Disable();
    }

    private void LookAt()
    {
        var direction = _bodyPhysics.velocity;
        direction.y = 0f;

        if (_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            _bodyPhysics.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _bodyPhysics.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera cam)
    {
        var forward = cam.transform.forward;
        forward.y = 0;
        return Vector3.forward.normalized;
    }

    private Vector3 GetCameraRight(Camera cam)
    {
        var right = cam.transform.right;
        right.y = 0;
        return Vector3.right.normalized;
    }
}