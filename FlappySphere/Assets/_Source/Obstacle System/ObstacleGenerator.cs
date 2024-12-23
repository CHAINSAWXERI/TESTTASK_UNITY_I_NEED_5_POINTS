using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] public ObjectPool objectPool;
    [SerializeField] public float spawnRate;
    [SerializeField] public float heightOffset;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        GameObject obstacle = objectPool.GetObject();
        if (obstacle != null)
        {
            float randomHeight = Random.Range(-heightOffset, heightOffset);
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomHeight, 0);
            obstacle.GetComponent<Obstacle>().Activate(spawnPosition);
        }
    }
}
