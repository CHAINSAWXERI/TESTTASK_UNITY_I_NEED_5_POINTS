using UnityEngine;

public class CoinPresenter : MonoBehaviour
{
    private CoinModel model;
    [SerializeField] private CoinView view;

    private void Start()
    {
        model = new CoinModel();
        view.UpdateCoinCount(model.CollectedCoins);
    }

    public void CollectCoin()
    {
        model.CollectCoin();
        view.UpdateCoinCount(model.CollectedCoins);
    }
}
