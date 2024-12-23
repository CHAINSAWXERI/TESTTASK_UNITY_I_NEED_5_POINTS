// Coin.cs
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ObjectPool pool; // Ссылка на пул объектов
    public float returnDelay = 2f; // Время ожидания перед возвратом

    private CoinPresenter presenter;

    private void Start()
    {
        presenter = FindObjectOfType<CoinPresenter>(); // Находим презентер на сцене
    }
}
