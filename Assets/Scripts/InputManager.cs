using UnityEngine;

public class InputManager : MonoBehaviour
{
    private const string HorizontalInputKey = "Horizontal";
    private const string VerticalInputKey = "Vertical";
    private const KeyCode JumpKeyCode = KeyCode.Space;
    
    private float _moveDeadZone = 0.1f;

    public Vector3 UserInput { get; private set; }
    public float UserXInput { get; private set; }
    public float UserZInput { get; private set; }

    public bool IsPressedJumpKey { get; private set; }

    private void Update()
    {
        UserInput = GetUserInput();
        UserXInput = UserInput.x;
        UserZInput = UserInput.z;

        if (HasPressedJumpKey())
            IsPressedJumpKey = true;
    }

    public void ResetJumpKey() => IsPressedJumpKey = false;

    public bool HasPressedJumpKey() => Input.GetKeyDown(JumpKeyCode);

    public bool HasInput() => UserInput.magnitude > _moveDeadZone;
    public Vector3 GetUserInput() => new Vector3(Input.GetAxisRaw(HorizontalInputKey), 0, Input.GetAxisRaw(VerticalInputKey));
}