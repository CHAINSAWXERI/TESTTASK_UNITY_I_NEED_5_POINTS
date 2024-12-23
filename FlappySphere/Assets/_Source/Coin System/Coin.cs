// Coin.cs
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ObjectPool pool; // ������ �� ��� ��������
    public float returnDelay = 2f; // ����� �������� ����� ���������

    private CoinPresenter presenter;

    private void Start()
    {
        presenter = FindObjectOfType<CoinPresenter>(); // ������� ��������� �� �����
    }
}
