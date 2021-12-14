using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using UnityEngine.Pool;
using System;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private ObjectPoolerModel poolableObject;
    [SerializeField] private int inactiveCount;
    [SerializeField] private int activeCount;

    ObjectPool<Poolable> pool;

    public int ActiveCount { get => activeCount; set => activeCount = value; }
    public int InactiveCount { get => inactiveCount; set => inactiveCount = value; }

    private void Awake()
    {
        pool = new ObjectPool<Poolable>(CreateGameObject, OnTakePoolableFromPool, OnReturnPoolableToPool);
        poolableObject.PoolableObject.gameObject.SetActive(false);
        for (int i = 0; i < poolableObject.PoolSize; i++)
        {
            var poolObject = pool.Get();
            poolObject.transform.SetParent(gameObject.transform);
        }
    }

    private void Update()
    {//gameObject.transform.position = ChooseRandomPosition();
        InactiveCount = pool.CountInactive;
        ActiveCount = pool.CountActive;     
    }

    private Poolable CreateGameObject()
    {
        var poolable = Instantiate(poolableObject.PoolableObject);
        poolable.SetPool(pool);
        return poolable;
    }

    private void OnTakePoolableFromPool(Poolable poolable)
    {
        poolable.gameObject.SetActive(true);
    }

    private void OnReturnPoolableToPool(Poolable poolable)
    {
        poolable.gameObject.SetActive(false);
    }

    private void ChooseRandomPosition()
    {
     // to do random placement
    }

}
