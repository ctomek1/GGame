using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class AttackState : BaseState
    {
        public AttackState(Enemy enemy) : base(enemy)
        {
        }

        public override Type Tick()
        {
            enemy.gameObject.transform.LookAt(target.transform);
            weaponView.Fire(target.transform.position);
            if(target == null)
            {
                return typeof(IddleState);
            }
            if(target.GetComponent<Health>().HpPoints == 0)
            {
                return typeof(DeathState);
            }
            return null;
        }
    }
}

