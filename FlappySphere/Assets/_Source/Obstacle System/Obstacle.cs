using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    public ObjectPool pool { private get; set; } // —сылка на пул объектов
    [SerializeField] public float speed;
    [SerializeField] public float returnDelay;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        StartCoroutine(ReturnToPoolAfterDelay());
    }

    public void Activate(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    private IEnumerator ReturnToPoolAfterDelay()
    {
        yield return new WaitForSeconds(returnDelay);

        pool.ReturnObject(this);
    }
}
