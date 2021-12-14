using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/BulletDamageModel")]
    public class BulletDamageModel : ScriptableObject
    {
        [SerializeField] int damage = 10;

        public int Damage { get => damage; }
    }
}
