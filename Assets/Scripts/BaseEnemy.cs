using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BaseEnemy : MonoBehaviour, ITriggerCheckable
{
    private Rigidbody2D rb;
    private Seeker seeker;
    private CircleCollider2D circleCollider;

    public Transform TargetLocation;
    public Transform SpawnLocation;
    public GameObject PowerUpDrop;
    
    [SerializeField] private bool _targetReached = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void FreezeCustomer()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(UnfreezeCustomer());
        _targetReached = true;
        circleCollider.enabled = false;
    }

    IEnumerator UnfreezeCustomer()
    {
        yield return new WaitForSeconds(3);
        rb.constraints = RigidbodyConstraints2D.None;
        DropPowerUp();
    }

    private void CustomerAtTarget()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, TargetLocation.transform.position);
        if(distanceFromTarget < 0.5f)
        {
            _targetReached = true;
        }
    }

    private void CustomerReturnToSpawnPoint()
    {
        float distanceFromSpawn = Vector3.Distance(transform.position, SpawnLocation.transform.position);
        if (distanceFromSpawn < 0.5f && _targetReached == true)
        {
            GameManager.Instance.ReduceCustomerCount(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IComputerBroke>() != null)
        {
            collision.gameObject.GetComponent<IComputerBroke>().ComputerBroken();
            circleCollider.enabled = false;
        }
    }

    public void AngryCustomerHit()
    {
        Debug.Log("Hit");
        FreezeCustomer();
    }

    private void DropPowerUp()
    {
        float randomChance = Random.value;
        if(randomChance <= 0.30f)
        {
            Instantiate(PowerUpDrop, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        CustomerAtTarget();
        CustomerReturnToSpawnPoint();
        if (_targetReached != true)
        {
            seeker.StartPath(rb.position, TargetLocation.position);
        }
        if (_targetReached == true)
        {
            seeker.StartPath(rb.position, SpawnLocation.position);
        }
    }
}

