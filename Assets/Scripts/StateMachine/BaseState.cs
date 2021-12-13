using System;
using Views;
using UnityEngine;

namespace StateMachine
{
    public abstract class BaseState : MonoBehaviour
    {
        [SerializeField] protected WeaponView weaponView;

        protected EnemyStateMachine enemy;

        private GameObject target;

            
        public GameObject Target { get => target; set => target = value; }

        public abstract Type Tick();
    }
}
