using System;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public event Action<float> OnDamageTaken;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out DamageDealer damageDealer))
        {
            OnDamageTaken?.Invoke(damageDealer.Damage);
        }
    }
}
