using UnityEngine;
using UnityEngine.Windows;

public class MoveController : MonoBehaviour
{
    private const string groundLayerName = "Ground";

    [SerializeField] private float _moveForce;
    [SerializeField] private float _jumpForce;

    private InputManager _inputManager;
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;

    private int groundLayerIndex;

    private bool _isMoving;
    private bool _isJumping;

    [SerializeField] private bool _isDisable;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputManager = GetComponent<InputManager>();

        groundLayerIndex = LayerMask.NameToLayer(groundLayerName);

        _startPosition = transform.position;
    }

    private void Start()
    {
        _rigidbody.centerOfMass = Vector3.zero;
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
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

    public void Stopped()
    {
        _isDisable = true; 

        _rigidbody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayerIndex)
            _isJumping = false;
    }
}
