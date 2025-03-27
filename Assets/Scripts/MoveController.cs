using UnityEngine;

public class MoveController : MonoBehaviour
{
    private const string GroundLayerName = "Ground";

    [SerializeField] private float _moveForce;
    [SerializeField] private float _jumpForce;

    private InputManager _inputManager;
    private Rigidbody _rigidbody;

    private int _groundLayerIndex;

    private bool _isMoving;
    private bool _isJumping;
    private bool _isDisable;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputManager = GetComponent<InputManager>();

        _groundLayerIndex = LayerMask.NameToLayer(GroundLayerName);
    }

    private void FixedUpdate()
    {
        if (_isDisable) 
            return;

        Move();
        Jump();
    }

    private void Move()
    {
        if (_isMoving = _inputManager.HasInput())
            MoveTo(_inputManager.UserInput);
    }

    public void MoveTo(Vector3 input)
    {
        _rigidbody.AddForce(input * _moveForce);
    }

    public void Jump()
    {
        if (_inputManager.IsPressedJumpKey)
        {
            if (_isJumping)
            {
                _inputManager.ResetJumpKey();
                return;
            }

            _rigidbody.AddForce(Vector3.up * _jumpForce);
            _isJumping = true;
            _inputManager.ResetJumpKey();
        }
    }

    public void Stop()
    {
        _isDisable = true; 

        _rigidbody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _groundLayerIndex)
            _isJumping = false;
    }
}