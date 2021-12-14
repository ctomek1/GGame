using System;
using UnityEngine;
using Views;

namespace Health
{
    public class Damagable : MonoBehaviour
    {
        public event Action<float> OnDamageTaken;

        private void OnCollisionEnter(Collision other)
        {
            if (!GetComponent<WeaponView>())
            {
                if (other.gameObject.TryGetComponent(out DamageDealer damageDealer))
                {
                    OnDamageTaken?.Invoke(damageDealer.Damage);
                    if(other.gameObject.CompareTag("Bullet"))
                    {
                        Destroy(other.gameObject);
                    }                
                }
            }   
        }
    }
}

