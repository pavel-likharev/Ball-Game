using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Transform _coinsContainer;
    [SerializeField] private float timeForCollectable = 30;

    private int _coinsForWin;
    private bool _isGameOver;

    private void Start()
    {
        _coinsForWin = _coinsContainer.childCount;

        PrintStartGameMessage();
    }

    private void Update()
    {
        if (_isGameOver)
            return;

        GameProcess();
    }

    private void PrintStartGameMessage()
    {
        Debug.Log("������ �� " + timeForCollectable + " ������ " + _coinsForWin + " �������!");
        Debug.Log("����� �����!");
    }

    private void GameProcess()
    {
        ReduceGameTimer();

        if (IsTimeOver())
        {
            LooseGame();
            return;
        }

        if (IsCoinsCollected())
        {
            WinGame();
            return;
        }
    }
    private void ReduceGameTimer()
    {
        timeForCollectable -= Time.deltaTime;
        PrintGameInfo();
    }

    private bool IsTimeOver() => timeForCollectable >= 0 ? false : true;

    private bool IsCoinsCollected() => _wallet.CollectedCoins >= _coinsForWin ? true : false;


    private void LooseGame()
    {
        Debug.Log("��������! �� �� ������ ������� ��� ������ :(");
        _ball.DisableBall();
        _isGameOver = true;
    }

    private void WinGame()
    {
        Debug.Log("������! �� ������� ��� ������ �� ���������� ����� :)");
        _isGameOver = true;
    }

    private void PrintGameInfo()
    {
        Debug.Log($"���������� �����: {timeForCollectable.ToString("00")}" +
            $" ������� �� ������ ��������: {_coinsForWin - _wallet.CollectedCoins}");
    }
}