using System;
using Models;
using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        public static event Action<PlayerView, Vector3> OnPlayerFired;

        [SerializeField] KillableCharacterModel playerModel;
        [SerializeField] Camera cam;
        [SerializeField] Animator anim;
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] Health.Health health;
        private static readonly int DIE_TRIGGER = Animator.StringToHash("Die");
        private bool isPlayerAlive = true;

        private int enemiesKilled;

        public bool IsPlayerAlive { get => isPlayerAlive; }
        public Health.Health Health { get => health;}
        public int EnemiesKilled { get => enemiesKilled; set => enemiesKilled = value; }

        private void Awake()
        {
            health.HpPoints = playerModel.HealthPoints;
        }

        private void OnEnable()
        {
            health.OnCharacterDead += PlayerDied;
        }

        void Update()
        {
            if(IsPlayerAlive)
            {
                playerMovement.HandleMovement();
                if (Input.GetMouseButton(0))
                {
                    var destination = GetFireDestination();
                    OnPlayerFired?.Invoke(this, destination);
                }
            }           
        }

        Vector3 GetFireDestination()
        {
            var ray = cam.ViewportPointToRay(
                new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y,
                    Input.mousePosition.z));
            return Physics.Raycast(ray, out var hit) ? hit.point : ray.GetPoint(1000);
        }

        public void Die()
        {
            anim.SetTrigger(DIE_TRIGGER);
            PlayerDied();
        }

        private void PlayerDied()
        {
            isPlayerAlive = false;
        }
    }
}