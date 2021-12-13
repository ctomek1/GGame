using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float hpPoints = 100f;
    [SerializeField]
    private Damagable damagable;
    public float HpPoints { get => hpPoints; set => hpPoints = value; }

    private void OnEnable()
    {
        damagable.OnDamageTaken += LoseHp;
    }

    private void LoseHp(float hpLoss)
    {
        hpPoints -= hpLoss;
    }
}
