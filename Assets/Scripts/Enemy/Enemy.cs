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
            { typeof(IddleState), GetComponent<IddleState>() },
            { typeof(AttackState), GetComponent<AttackState>() },
            { typeof(DeathState), GetComponent<DeathState>() }
        };
        StateMachineManager stateMachineManager = GetComponent<StateMachineManager>();
        stateMachineManager.SetStates(states);
    }
}
