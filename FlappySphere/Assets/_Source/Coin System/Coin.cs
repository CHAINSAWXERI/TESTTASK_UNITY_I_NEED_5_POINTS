// Coin.cs
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinObjectPool pool; // ������ �� ��� ��������
    [SerializeField] public float speed;
    public float returnDelay = 2f; // ����� �������� ����� ���������

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
