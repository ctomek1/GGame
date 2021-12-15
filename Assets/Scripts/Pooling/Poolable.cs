using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;

public class Poolable : MonoBehaviour
{
    IObjectPool<Poolable> pool;

    public void SetPool(IObjectPool<Poolable> pool) => this.pool = pool;

    public event Action<Poolable> OnPoolableDisabled;

    private void OnDisable()
    {
        OnPoolableDisabled?.Invoke(this);
    }

    public void ReturnToPool()
    {
        if(pool != null)
        {
            pool.Release(this);           
        }
    }
}
