using UnityEngine;

// CoinModel.cs
public class CoinModel
{
    public int CollectedCoins { get; private set; }

    public void CollectCoin()
    {
        CollectedCoins++;
    }
}
