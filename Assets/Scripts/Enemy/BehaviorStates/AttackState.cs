using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class AttackState : BaseState
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override Type Tick()
        {
            IddleState iddleState = GetComponent<IddleState>();
            Target = iddleState.Target;
            Debug.LogError("target: " + Target);
            Debug.LogError(enemy);
            enemy.gameObject.transform.LookAt(Target.transform);
            weaponView.Fire(Target.transform.position);
            if(Target == null)
            {
                return typeof(IddleState);
            }
            if(Target.GetComponent<Health>().HpPoints == 0)
            {
                return typeof(DeathState);
            }
            return null;
        }
    }
}

