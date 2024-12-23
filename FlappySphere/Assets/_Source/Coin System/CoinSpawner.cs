using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] public CoinObjectPool objectPool; // ��� �������� ��� �����
    [SerializeField] public float spawnRate; // ������� ������ �����
    [SerializeField] public float heightOffset; // �������� �� ������

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnCoin();
            timer = 0;
        }
    }

    void SpawnCoin()
    {
        GameObject coin = objectPool.GetObject(); // �������� ������ �� ����
        if (coin != null)
        {
            float randomHeight = Random.Range(-heightOffset, heightOffset); // ���������� ��������� �������� �� ������
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomHeight, 0); // ��������� ������� ������
            coin.GetComponent<Coin>().Activate(spawnPosition); // ���������� ������ � �������� �������
        }
    }
}
