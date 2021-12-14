using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float hpPoints = 100f;
        [SerializeField]
        private Damagable damagable;
        [SerializeField]
        private float invincibilityFrameTime = 1f;

        public event Action OnCharacterDead;

        private bool isInvincible = false;
        public float HpPoints { get => hpPoints; set => hpPoints = value; }

        private void OnEnable()
        {
            damagable.OnDamageTaken += LoseHp;
        }

        private void LoseHp(float hpLoss)
        {            
            if(isInvincible == false)
            {                
                hpPoints -= hpLoss;
                if (CheckIfDead())
                {
                    OnCharacterDead?.Invoke();
                }
                StartCoroutine(Invincibility());
            }               
        }

        private bool CheckIfDead()
        {
            return hpPoints <= 0;
        }

        private IEnumerator Invincibility()
        {
            isInvincible = true;
            yield return invincibilityFrameTime;
            isInvincible = false;
        }
    }
}


