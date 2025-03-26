using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private CoinsController _coinsController;

    [SerializeField] private float timeForCollectable = 30;

    private bool _isGameOver;

    private void Start()
    {
        Debug.Log("������ �� " + timeForCollectable + " ������ " + _coinsController.CoinsAmount + " �������!");
        Debug.Log("����� �����!");
    }

    private void Update()
    {
        if (_isGameOver)
            return;

        CheckCoins();
        CheckTime();
    }

    private void CheckTime()
    {
        if (_isGameOver)
            return;

        timeForCollectable -= Time.deltaTime;

        Debug.Log($"���������� �����: {timeForCollectable.ToString("00")}" +
            $" ������� �� ������ ��������: {_coinsController.GetCurrentCoinsAmount()}");

        if (timeForCollectable <= 0)
        {
            Debug.Log("��������! �� �� ������ ������� ��� ������ :(");
            _ball.DisableBall();
            _isGameOver = true;
        }
    }

    private void CheckCoins()
    {
        if (_ball.CollectableCoins >= _coinsController.CoinsAmount)
        {
            Debug.Log("������! �� ������� ��� ������ �� ���������� ����� :)");
            _isGameOver = true;
        }
    }
}
