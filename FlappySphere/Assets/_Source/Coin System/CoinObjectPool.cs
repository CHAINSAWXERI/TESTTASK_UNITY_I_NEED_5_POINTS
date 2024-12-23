using System.Collections.Generic;
using UnityEngine;

public class CoinObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // Префаб для создания объектов
    [SerializeField] private int poolSize = 10; // Размер пула
    private List<Coin> pool; // Список для хранения объектов

    void Start()
    {
        pool = new List<Coin>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            Coin coin = obj.GetComponent<Coin>();
            coin.pool = this; // Устанавливаем ссылку на пул
            obj.SetActive(false);
            pool.Add(coin); // Добавляем объект в пул
        }
    }

    public GameObject GetObject()
    {
        foreach (Coin coin in pool)
        {
            if (!coin.gameObject.activeInHierarchy)
            {
                coin.gameObject.SetActive(true); // Активируем объект
                return coin.gameObject;
            }
        }

        // Если нет доступных объектов, создаем новый
        GameObject newObj = Instantiate(prefab);
        Coin newCoin = newObj.GetComponent<Coin>();
        newCoin.pool = this;
        newObj.SetActive(false);
        pool.Add(newCoin); // Добавляем новый объект в пул
        return newObj;
    }

    public void ReturnObject(Coin coin)
    {
        coin.gameObject.SetActive(false); // Деактивируем объект
    }
}
