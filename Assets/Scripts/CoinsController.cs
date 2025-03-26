using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    [SerializeField] private List<GameObject> coins;
    
    public int CoinsAmount { get; private set; }
    

    private void Awake()
    {
        CoinsAmount = transform.childCount;
    }

    public int GetCurrentCoinsAmount() => transform.childCount;
}
