using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class DeathState : BaseState
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override Type Tick()
        {
            throw new NotImplementedException();
        }
    }
}
