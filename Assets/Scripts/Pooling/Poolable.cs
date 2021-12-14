using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Poolable : MonoBehaviour
{
    IObjectPool<Poolable> pool;

    public void SetPool(IObjectPool<Poolable> pool) => this.pool = pool;

    public void ReturnToPool()
    {
        if(pool != null)
        {
            pool.Release(this);
        }
    }
}
