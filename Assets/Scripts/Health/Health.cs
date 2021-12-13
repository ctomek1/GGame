using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float hpPoints = 100f;

    public float HpPoints { get => hpPoints; set => hpPoints = value; }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out DamageDealer damageDealer))
        {
            HpPoints -= damageDealer.Damage;
        }
    }
}
