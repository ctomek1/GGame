using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private float damage;

        public float Damage { get => damage; set => damage = value; }
    }
}

