using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class IddleState : BaseState
    {       
        [SerializeField] private float aggroRange;
        private PlayerView player;
        protected void Awake()
        {
            GetComponent<SphereCollider>().radius = weaponView.WeaponRangeForEnemies;
            player = FindObjectOfType<PlayerView>();
        }

        public override Type Tick()
        {
            var distance = Vector3.Distance(player.gameObject.transform.position, transform.position);
            if(distance <= aggroRange && player.IsPlayerAlive)
            {
                return typeof(ChaseState);
            }
            return null;
        }
    }    
}

