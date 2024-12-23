using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] public CoinObjectPool objectPool; // Пул объектов для монет
    [SerializeField] public float spawnRate; // Частота спавна монет
    [SerializeField] public float heightOffset; // Смещение по высоте

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
        GameObject coin = objectPool.GetObject(); // Получаем объект из пула
        if (coin != null)
        {
            float randomHeight = Random.Range(-heightOffset, heightOffset); // Генерируем случайное смещение по высоте
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomHeight, 0); // Вычисляем позицию спавна
            coin.GetComponent<Coin>().Activate(spawnPosition); // Активируем монету и передаем позицию
        }
    }
}
