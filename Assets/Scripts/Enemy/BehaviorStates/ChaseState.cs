using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class ChaseState : BaseState
    {
        [SerializeField] private float speed;
        private PlayerView player;
        protected  void Awake()
        {
            GetComponent<SphereCollider>().radius = weaponView.WeaponRangeForEnemies;
            player = FindObjectOfType<PlayerView>();
        }

        public override Type Tick()
        {
            if (!player.IsPlayerAlive)
            {
                return typeof(IddleState);
            }
            gameObject.transform.parent.LookAt(player.transform);
            gameObject.transform.parent.position = Vector3.MoveTowards(gameObject.transform.position, player.gameObject.transform.position, speed * Time.deltaTime);       
            if (Target != null)
            {
                return typeof(AttackState);
            }
            return null;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Target = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Target = null;
            }
        }
    }

}

