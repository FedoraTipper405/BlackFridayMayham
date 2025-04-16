using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    private List<GameObject> _poolObjects = new List<GameObject>();
    
    [SerializeField] private int _amountToPool;
    [SerializeField] private GameObject _bulletPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = Instantiate(_bulletPrefab);
            obj.SetActive(false);
            _poolObjects.Add(obj);
        }
    }

    public GameObject GetBulletPrefab()
    {
        for (int i = 0; i < _poolObjects.Count; i++)
        {
            if (!_poolObjects[i].activeInHierarchy)
            {
                return _poolObjects[i];
            }
        }

        return null;
    }
}
