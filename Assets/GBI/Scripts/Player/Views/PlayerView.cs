using UnityEngine;

namespace Geekbrains
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : BaseView<PlayerModel>, IEventListener<PlayerEventArgs>
    {
        private Transform _cam;
        private Vector3 _camForward;
        private Vector3 _move;
        private Rigidbody _rigidbody;
        private Vector3 _movement;

        private float _turnAmount;
        private float _forwardAmount;
        private float _movingTurnSpeed = 360.0f;
        private float _stationaryTurnSpeed = 180.0f;
        private float _moveSpeed = 3.0f;
        private float _turnSpeed;

        private float _smoothing = 0.3f;
        private float _rotationSpeedX = 10.0f;
        private float _rotationSpeedY = 5.0f;
        private float _distance = -7.0f;
        private float _rotationX = 0;
        private float _rotationY = 0;
        private float _yMinLimit = 0f;
        private float _yMaxLimit = 60.0f;

        private const float _minAngleForMove = 185.0f;

        private void Awake()
        {
            if (Camera.main != null)
            {
                _cam = Camera.main.transform;
            }

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        public void HandleEvent(PlayerEventArgs eventArgs)
        {
            Movement(eventArgs.HorizontalAxis, eventArgs.VerticalAxis, eventArgs.FixedTime);
            CameraRotate(eventArgs.MouseXAxis, eventArgs.MouseYAxis);
        }

        private void CameraRotate(float mouseXAxis, float mouseYAxis)
        {
            _rotationX += mouseXAxis * _rotationSpeedX;
            _rotationY += mouseYAxis * _rotationSpeedY;

            _rotationY = Mathf.Clamp(_rotationY, _yMinLimit, _yMaxLimit);

            Quaternion rotation = Quaternion.Euler(_rotationY, _rotationX, 0);

            Vector3 distance = new Vector3(0, 0, _distance);
            Vector3 position = rotation * distance + transform.position;

            _cam.transform.rotation = Quaternion.Lerp(_cam.transform.rotation, rotation, _smoothing);
            _cam.transform.position = Vector3.Slerp(_cam.transform.position, position, _smoothing);

            _cam.transform.LookAt(gameObject.transform);
        }

        private void Movement(float horizontalAxis, float verticalAxis, float fixedTime)
        {
            if (_cam != null)
            {
                _camForward = Vector3.Scale(_cam.forward, new Vector3(1, 0, 1)).normalized;
                _move = verticalAxis * _camForward + horizontalAxis * _cam.right;
            }
            else
            {
                _move = verticalAxis * Vector3.forward + horizontalAxis * Vector3.right;
            }

            if (_move.magnitude > 1f)
            {
                _move.Normalize();
            }

            _move = transform.InverseTransformDirection(_move);
            _turnAmount = Mathf.Atan2(_move.x, _move.z);
            _forwardAmount = _move.z;

            Turn(fixedTime);

            Move(fixedTime);
        }

        private void Turn(float fixedTime)
        {
            _turnSpeed = Mathf.Lerp(_stationaryTurnSpeed, _movingTurnSpeed, _forwardAmount);
            transform.Rotate(0, _turnAmount * _turnSpeed * fixedTime, 0);
        }

        private void Move(float fixedTime)
        {
            _movement = transform.forward * _forwardAmount * _moveSpeed * fixedTime;

            if (_turnSpeed > _minAngleForMove)
            {
                _rigidbody.MovePosition(_rigidbody.position + _movement);
            }
        }
    } 
}
