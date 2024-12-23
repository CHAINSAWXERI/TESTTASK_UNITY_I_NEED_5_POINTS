using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour
{
    public TMP_Text coinCountText;

    public void UpdateCoinCount(int count)
    {
        coinCountText.text = "Coins: " + count;
    }
}

