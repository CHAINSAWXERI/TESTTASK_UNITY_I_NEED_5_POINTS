using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float flapForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CoinPresenter coinPresenter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    void Flap()
    {
        rb.linearVelocity = Vector2.up * flapForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            coinPresenter.CollectCoin();
        }
    }
}
