using UnityEngine;

public class Wallet : MonoBehaviour
{   
    public int CollectedCoins { get; private set; }

    private void AddCoin() => CollectedCoins++;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(coin.gameObject);
            AddCoin();
        }
    }
}