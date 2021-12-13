using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class IddleState : BaseState
    {
        public IddleState(Enemy enemy) : base(enemy)
        {
        }

        public override Type Tick()
        {
            Debug.LogError(target);
            if (target != null)
            {
                return typeof(AttackState);               
            }
            return null;
        }

    }
}

