using UnityEngine;

public class Ball : MonoBehaviour
{
    private const string CoinTag = "Coin";

    private MoveController _moveController;

    public int CollectableCoins { get; private set; }

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
    }

    public void DisableBall()
    {
        _moveController.Stopped();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CoinTag)
        {
            Destroy(other.gameObject);
            CollectableCoins++;
        }
    }
}