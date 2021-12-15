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
    int inactiveCount;

    public ObjectPool<Poolable> Pool { get => pool; set => pool = value; }
    public int InactiveCount { get => inactiveCount; set => inactiveCount = value; }

    private void Awake()
    {
        Pool = new ObjectPool<Poolable>(CreateGameObject, OnTakePoolableFromPool, OnReturnPoolableToPool);
        InactiveCount = pool.CountInactive;
    }

    private Poolable CreateGameObject()
    {
        var poolable = Instantiate(poolableObject.PoolableObject);
        poolable.SetPool(Pool);
        return poolable;
    }

    private void OnTakePoolableFromPool(Poolable poolable)
    {
        poolable.gameObject.transform.position = GetRandomPosition();
        poolable.gameObject.SetActive(true);
    }

    private void OnReturnPoolableToPool(Poolable poolable)
    {       
        poolable.gameObject.transform.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        var index = UnityEngine.Random.Range(0, positions.Count);
        return positions[index].position + new Vector3(UnityEngine.Random.Range(0, 2), 0, UnityEngine.Random.Range(0, 2));
    }

}
