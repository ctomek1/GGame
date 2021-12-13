using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class IddleState : BaseState
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override Type Tick()
        {
            if (Target != null)
            {
                return typeof(AttackState);               
            }
            return null;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                Target = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Target = null;
            }
        }
    }
}

