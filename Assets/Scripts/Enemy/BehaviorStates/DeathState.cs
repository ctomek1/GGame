using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class DeathState : BaseState
    {
        protected void Awake()
        {
            enemy = GetComponent<EnemyStateMachine>();
        }

        public override Type Tick()
        {
            throw new NotImplementedException();
        }
    }
}
