using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using UnityEngine.Pool;
using System;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private ObjectPoolerModel poolableObject;
    [SerializeField] private List<Transform> positions;

    ObjectPool<Poolable> pool;

    private void Awake()
    {
        pool = new ObjectPool<Poolable>(CreateGameObject, OnTakePoolableFromPool, OnReturnPoolableToPool);
        for (int i = 0; i < poolableObject.PoolSize; i++)
        {
            var poolObject = pool.Get();
            poolObject.gameObject.SetActive(false);
            poolObject.gameObject.transform.position = GetRandomPosition().position;
            poolObject.transform.SetParent(gameObject.transform);
        }
    }

    private Poolable CreateGameObject()
    {
        var poolable = Instantiate(poolableObject.PoolableObject);
        poolable.SetPool(pool);
        return poolable;
    }

    private void OnTakePoolableFromPool(Poolable poolable)
    {
        poolable.gameObject.transform.position = GetRandomPosition().position;
        poolable.gameObject.SetActive(true);
    }

    private void OnReturnPoolableToPool(Poolable poolable)
    {
        poolable.gameObject.SetActive(false);
    }

    private Transform GetRandomPosition()
    {
        var index = UnityEngine.Random.Range(0, positions.Count);
        return positions[index];
    }

}
