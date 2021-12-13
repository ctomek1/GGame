using System;
using UnityEngine;
using Views;

namespace StateMachine
{
    public class ChaseState : BaseState
    {
        [SerializeField] private float speed;
        private PlayerInput player;
        protected  void Awake()
        {
            enemy = GetComponent<EnemyStateMachine>();
            GetComponent<SphereCollider>().radius = weaponView.WeaponRangeForEnemies;
            player = FindObjectOfType<PlayerInput>();
        }

        public override Type Tick()
        {
            enemy.gameObject.transform.parent.LookAt(player.transform);
            enemy.gameObject.transform.parent.position = Vector3.MoveTowards(enemy.gameObject.transform.position, player.gameObject.transform.position, speed * Time.deltaTime);       
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

