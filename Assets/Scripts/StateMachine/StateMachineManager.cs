using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class StateMachineManager : MonoBehaviour
    {
        private Dictionary<Type, BaseState> availableStates;

        public BaseState CurrentState { get; private set; }
        public event Action<BaseState> OnStateChanged;

        public void SetStates(Dictionary<Type, BaseState> states)
        {
            availableStates = states;
        }

        private void Update()
        {
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
