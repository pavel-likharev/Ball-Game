using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private int _rightSide = 1;
    private int _leftSide = -1;
    private int _currentSide;

    private void Start()
    {
        DetermineSide();
    }

    private void DetermineSide()
    {
        int chance = Random.Range(0, 2);
        _currentSide = chance == 0 ? _leftSide : _rightSide;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime * _currentSide);
    }
}