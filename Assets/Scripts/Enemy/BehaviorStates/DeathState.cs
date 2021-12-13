using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class DeathState : BaseState
{
        public DeathState(Enemy enemy) : base(enemy)
        {
        }

        public override Type Tick()
        {
            throw new NotImplementedException();
        }
    }
}
