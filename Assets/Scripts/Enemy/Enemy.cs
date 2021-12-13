using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using System;
using System.Linq;

public class Enemy : MonoBehaviour
{

    private void Awake()
    {
        Debug.LogError("hi");
        InitializeStateMachine();       
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(IddleState), new IddleState(this) },
            { typeof(AttackState), new AttackState(this) },
            { typeof(DeathState), new DeathState(this) }
        };
        StateMachineManager stateMachineManager = GetComponent<StateMachineManager>();
        stateMachineManager.SetStates(states);
    }
}
