using UnityEngine;

public class CoinsController : MonoBehaviour
{   
    public int CoinsAmount { get; private set; }
    
    private void Awake()
    {
        CoinsAmount = transform.childCount;
    }

    public int GetCurrentCoinsAmount() => transform.childCount;
}