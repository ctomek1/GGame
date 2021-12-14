using System;
using System.Collections.Generic;
using System.Linq;
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

        private void FixedUpdate()
        {
            if (CurrentState == null)
            {
                CurrentState = availableStates.Values.First();
            }
            var nextState = CurrentState?.Tick();
            if (nextState != null &&
                nextState != CurrentState?.GetType())
            {
                SwitchToNewState(nextState);
            }
        }

        public void SwitchToNewState(Type nextState)
        {
            CurrentState = availableStates[nextState];
            OnStateChanged?.Invoke(CurrentState);
        }
    }   

}
