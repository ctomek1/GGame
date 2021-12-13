using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
using System.Linq;

namespace StateMachine
{
     public class EnemyStateMachine : MonoBehaviour
     {

        private void Awake()
        {
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            var states = new Dictionary<Type, BaseState>()
        {
            { typeof(IddleState), GetComponent<IddleState>() },
            { typeof(ChaseState), GetComponent<ChaseState>() },
            { typeof(AttackState), GetComponent<AttackState>() },
            { typeof(DeathState), GetComponent<DeathState>() }
        };
            StateMachineManager stateMachineManager = GetComponent<StateMachineManager>();
            stateMachineManager.SetStates(states);
        }
     }
}

