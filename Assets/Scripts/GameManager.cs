using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private CoinsController _coinsController;

    [SerializeField] private float timeForCollectable = 30;

    private bool _isGameOver;

    private void Start()
    {
        Debug.Log("Собери за " + timeForCollectable + " секунд " + _coinsController.CoinsAmount + " монеток!");
        Debug.Log("Время пошло!");
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

        Debug.Log($"Оставшееся время: {timeForCollectable.ToString("00")}" +
            $" Монеток на уровне осталось: {_coinsController.GetCurrentCoinsAmount()}");

        if (timeForCollectable <= 0)
        {
            Debug.Log("ПРОИГРЫШ! Вы не успели собрать все монеты :(");
            _ball.DisableBall();
            _isGameOver = true;
        }
    }

    private void CheckCoins()
    {
        if (_ball.CollectableCoins >= _coinsController.CoinsAmount)
        {
            Debug.Log("ПОБЕДА! Вы собрали все монеты за отведенное время :)");
            _isGameOver = true;
        }
    }
}
