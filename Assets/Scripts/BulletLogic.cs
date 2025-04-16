using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speedOfBullet;
    [SerializeField] private float _lifeTimeOfBullet;
    private Rigidbody2D rb;
    private float _timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ShootBullet(Transform shootPoint)
    {
        _timer = 0;
        transform.position = shootPoint.transform.position;
        transform.rotation = shootPoint.transform.rotation;
        rb.AddForce(transform.up * _speedOfBullet, ForceMode2D.Impulse);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifeTimeOfBullet)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ITriggerCheckable customerHit = collision.gameObject.GetComponent<ITriggerCheckable>();
        if (customerHit != null)
        {
            customerHit.AngryCustomerHit();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
    }
}
