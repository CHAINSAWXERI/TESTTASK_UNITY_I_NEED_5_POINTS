using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public int poolSize;

    private List<Obstacle> pool;

    void Start()
    {
        pool = new List<Obstacle>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            Obstacle obstacle = obj.GetComponent<Obstacle>();
            obstacle.pool = this;
            obj.SetActive(false);
            pool.Add(obstacle);
        }
    }

    public GameObject GetObject()
    {
        foreach (Obstacle obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj.gameObject;
            }
        }


        GameObject newObj = Instantiate(prefab);
        Obstacle newObstacle = newObj.GetComponent<Obstacle>();
        newObstacle.pool = this;
        newObj.SetActive(false);
        pool.Add(newObstacle);
        return newObj;
    }

    public void ReturnObject(Obstacle obj)
    {
        obj.gameObject.SetActive(false);
    }
}
