using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class AttackState : BaseState
    {
        protected void Awake()
        {
            enemy = GetComponent<EnemyStateMachine>();
        }

        public override Type Tick()
        {
            Debug.LogError(Target);
            ChaseState chaseState = GetComponent<ChaseState>();
            Target = chaseState.Target;

            if(Target != null)
            {
                enemy.gameObject.transform.parent.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));
                weaponView.Fire(Target.transform.position);
            }     
            
            if(Target == null || Target.GetComponent<Health>().HpPoints == 0)
            {
                return typeof(IddleState);
            }
            return null;
        }
    }
}

