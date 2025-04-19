using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _randomTargetLocation;
    [SerializeField] private List<Transform> _randomSpawnlocation;
    [SerializeField] private GameObject _customerPrefab;
    [SerializeField] private float _maxNumberOfCustomers;
    [SerializeField] private float _timeUntilNextCustomer;
    private int _numberOfCustomers;

    private void Start()
    {
        StartCoroutine(WaitTimer());
    }

    IEnumerator WaitTimer()
    {
        yield return new WaitForSeconds(_timeUntilNextCustomer);
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if(_numberOfCustomers < _maxNumberOfCustomers)
        {
            int randomSpawnIndex = Random.Range(0, _randomSpawnlocation.Count);
            int randomTargetIndex = Random.Range(0, _randomTargetLocation.Count);

            GameObject spawnedCustomer = Instantiate(_customerPrefab, _randomSpawnlocation[randomSpawnIndex].transform.position, Quaternion.identity);
            
            BaseEnemy customerScript = spawnedCustomer.GetComponent<BaseEnemy>();

            customerScript.SpawnLocation = _randomSpawnlocation[randomSpawnIndex];
            customerScript.TargetLocation = _randomTargetLocation[randomTargetIndex];

            _randomTargetLocation.Remove(_randomTargetLocation[randomTargetIndex]);
            StartCoroutine(WaitTimer());
            _numberOfCustomers++;
        }
    }
}
