using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class IddleState : BaseState
    {       
        [SerializeField] private float aggroRange;
        private PlayerInput player;
        protected void Awake()
        {
            enemy = GetComponent<EnemyStateMachine>();
            GetComponent<SphereCollider>().radius = weaponView.WeaponRangeForEnemies;
            player = FindObjectOfType<PlayerInput>();
        }

        public override Type Tick()
        {
            var distance = Vector3.Distance(player.gameObject.transform.position, transform.position);
            if(distance <= aggroRange)
            {
                return typeof(ChaseState);
            }
            return null;
        }
    }    
}

