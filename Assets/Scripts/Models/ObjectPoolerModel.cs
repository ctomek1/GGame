using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/ObjectPoolerModel")]
    public class ObjectPoolerModel : ScriptableObject
    {
        [SerializeField] private GameObject objectToPool;
        [SerializeField] private int poolSize;
        [SerializeField] private string objectName;

        public GameObject ObjectToPool { get => objectToPool; set => objectToPool = value; }
        public int PoolSize { get => poolSize; set => poolSize = value; }
    }
}
