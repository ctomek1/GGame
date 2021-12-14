using System;
using Views;

namespace StateMachine
{
    public class DeathState : BaseState
    {
        protected void Awake()
        {           
        }

        public override Type Tick()
        {
            //getback enemy to spawner TODO
            this.transform.parent.gameObject.SetActive(false);
            return typeof(IddleState);
        }
    }
}
