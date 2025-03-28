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
        Debug.Log("Собери за " + timeForCollectable + " секунд " + _coinsForWin + " монеток!");
        Debug.Log("Время пошло!");
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
        Debug.Log("ПРОИГРЫШ! Вы не успели собрать все монеты :(");
        _ball.DisableBall();
        _isGameOver = true;
    }

    private void WinGame()
    {
        Debug.Log("ПОБЕДА! Вы собрали все монеты за отведенное время :)");
        _isGameOver = true;
    }

    private void PrintGameInfo()
    {
        Debug.Log($"Оставшееся время: {timeForCollectable.ToString("00")}" +
            $" Монеток на уровне осталось: {_coinsForWin - _wallet.CollectedCoins}");
    }
}