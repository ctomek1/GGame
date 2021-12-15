using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Models
{
    [CreateAssetMenu(menuName = "Models/ObjectPoolerModel")]
    public class ObjectPoolerModel : ScriptableObject
    {
        [SerializeField] private Poolable poolableObject;

        public Poolable PoolableObject { get => poolableObject; set => poolableObject = value; }
    }
}
