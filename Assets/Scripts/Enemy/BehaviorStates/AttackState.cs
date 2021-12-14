using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class AttackState : BaseState
    {
        private PlayerView player;
        protected void Awake()
        {
            player = FindObjectOfType<PlayerView>();
        }

        private void OnEnable()
        {
            Target = null;
        }

        public override Type Tick()
        {
            if (!player.IsPlayerAlive)
            {
                return typeof(IddleState);
            }

            ChaseState chaseState = GetComponent<ChaseState>();
            Target = chaseState.Target;

            if (!player.IsPlayerAlive)
            {
                return typeof(IddleState);
            }
            if (Target != null)
            {
                transform.parent.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));
                weaponView.Fire(Target.transform.position);
            }
            else
            {
                return typeof(IddleState);
            }           
            return null;
        }
    }
}

