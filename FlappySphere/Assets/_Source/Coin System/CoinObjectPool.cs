using System.Collections.Generic;

using UnityEngine;

/// ObjectPool.cs
public class CoinObjectPool : MonoBehaviour
{
    public GameObject prefab; // ������ ��� �������� ��������
    public int poolSize = 10; // ������ ����

    private Queue<GameObject> poolQueue;

    private void Start()
    {
        poolQueue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (poolQueue.Count > 0)
        {
            GameObject obj = poolQueue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return null; // ���� ��� ��������� �������� � ����
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        poolQueue.Enqueue(obj);
    }
}
