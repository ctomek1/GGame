using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachineManager : MonoBehaviour
    {
        private Dictionary<Type, BaseState> availableStates;

        [SerializeField]
        private BaseState currentState;

        public BaseState CurrentState { get => currentState; set => currentState = value; }

        public event Action<BaseState> OnStateChanged;

        public void SetStates(Dictionary<Type, BaseState> states)
        {
            availableStates = states;
        }

        private void Update()
        {
            Debug.LogError(availableStates[typeof(IddleState)]);
            if (CurrentState == null)
            {
                CurrentState = availableStates[typeof(IddleState)];
            }
            var nextState = CurrentState?.Tick();
            if (nextState != null &&
                nextState != CurrentState?.GetType())
            {
                SwitchToNewState(nextState);
            }
        }

        private void SwitchToNewState(Type nextState)
        {
            CurrentState = availableStates[nextState];
            OnStateChanged?.Invoke(CurrentState);
        }
    }   

}
