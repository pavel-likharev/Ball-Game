using UnityEngine;

public class Ball : MonoBehaviour
{
    private MoveController _moveController;

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
    }

    public void DisableBall()
    {
        if (_moveController != null)
            _moveController.Stop();
    }
}