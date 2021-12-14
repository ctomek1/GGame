using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/BulletDamageModel")]
    public class BulletDamageModel : ScriptableObject
    {
        [SerializeField] float damage = 10;
        [SerializeField] float critChance;
        [SerializeField] float critMultiplier;

        private bool isCrit;
        public float Damage { get
            {
                if(CheckIfCrit())
                {
                    return damage * critMultiplier;
                }
                return damage;
            } }

        private bool CheckIfCrit()
        {
            var rollChance = Random.Range(0, 100);
            if(rollChance <= critChance)
            {
                return true;
            }
            return false;
        }
    }
}
