using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _maxRotateValue = 30;

    private InputManager _inputManager;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (_inputManager.HasInput())
        {
            Vector3 direction = new Vector3(_inputManager.UserZInput, 0, -_inputManager.UserXInput);
            transform.Rotate(direction * _rotateSpeed * Time.deltaTime);
        }
    }
}