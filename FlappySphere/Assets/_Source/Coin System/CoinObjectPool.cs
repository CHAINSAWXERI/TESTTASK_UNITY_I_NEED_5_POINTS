using System.Collections.Generic;
using UnityEngine;

public class CoinObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab; // ������ ��� �������� ��������
    [SerializeField] private int poolSize = 10; // ������ ����
    private List<Coin> pool; // ������ ��� �������� ��������

    void Start()
    {
        pool = new List<Coin>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            Coin coin = obj.GetComponent<Coin>();
            coin.pool = this; // ������������� ������ �� ���
            obj.SetActive(false);
            pool.Add(coin); // ��������� ������ � ���
        }
    }

    public GameObject GetObject()
    {
        foreach (Coin coin in pool)
        {
            if (!coin.gameObject.activeInHierarchy)
            {
                coin.gameObject.SetActive(true); // ���������� ������
                return coin.gameObject;
            }
        }

        // ���� ��� ��������� ��������, ������� �����
        GameObject newObj = Instantiate(prefab);
        Coin newCoin = newObj.GetComponent<Coin>();
        newCoin.pool = this;
        newObj.SetActive(false);
        pool.Add(newCoin); // ��������� ����� ������ � ���
        return newObj;
    }

    public void ReturnObject(Coin coin)
    {
        coin.gameObject.SetActive(false); // ������������ ������
    }
}
