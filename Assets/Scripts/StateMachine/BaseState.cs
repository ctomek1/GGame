using System;
using Views;
using UnityEngine;

namespace StateMachine
{
    public abstract class BaseState
    {
        [SerializeField] protected WeaponView weaponView;
        
        protected BaseState(Enemy enemy)
        {
            this.enemy = enemy;
        }

        protected Enemy enemy;
        public GameObject target;

        public abstract Type Tick();
    }
}
