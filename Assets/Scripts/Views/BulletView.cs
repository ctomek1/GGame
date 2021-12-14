using UnityEngine;
using Health;
using Models;

namespace Views
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] float autoDestroyAfterSeconds = 4f;
        [SerializeField] BulletDamageModel bulletDamage;

        void Start()
        {
            var damage = GetComponent<DamageDealer>();
            damage.Damage = bulletDamage.Damage;
            Destroy(gameObject, autoDestroyAfterSeconds);            
        }
    }
}