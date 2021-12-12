using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float hpPoints = 100f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out DamageDealer damageDealer))
        {
            hpPoints -= damageDealer.Damage;
        }
    }
}
