using UnityEngine;
using UnityEngine.InputSystem;

/*
 * CameraProfiler
 * Script for getting Camera to follow the player.
 */
namespace Player
{
    public class CameraProfiler : MonoBehaviour
    {
        public float smoothSpeed = 0.15f;
        private Vector3 _offset;
        private Transform _target;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            _offset = transform.position - _target.position;
        }

        // Update camera's desiredPosition of the target.
        private void LateUpdate()
        {
            var desiredPosition = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            RotateRound();
        }

        private void RotateRound()
        {
            var yPositive = new Vector3(0f, 2.5f, 0f);
            var yNegative = new Vector3(0f, -2.5f, 0f);

            if (Gamepad.all[0].rightStick.right.isPressed)
                transform.Rotate(yPositive, Space.World);
            else if (Gamepad.all[0].rightStick.left.isPressed)
                transform.Rotate(yNegative, Space.World);
        }
    }
}