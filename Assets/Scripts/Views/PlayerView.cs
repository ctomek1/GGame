using System;
using Models;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] GameObject restartButton;

        private static readonly int DIE_TRIGGER = Animator.StringToHash("Die");
        private bool isPlayerAlive = true;
        private int enemiesKilled;

        public bool IsPlayerAlive { get => isPlayerAlive; }
        public Health.Health Health { get => health;}
        public int EnemiesKilled { get => enemiesKilled; set => enemiesKilled = value; }
        public GameObject RestartButton { get => restartButton; set => restartButton = value; }

        private void Awake()
        {
            health.HpPoints = playerModel.HealthPoints;
        }

        private void OnEnable()
        {
            health.OnCharacterDead += PlayerDied;
        }

        private void OnDisable()
        {
            health.OnCharacterDead -= PlayerDied;
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.CompareTag("Enemy"))
                {
                    return hit.collider.transform.position;
                }
                else
                {
                    return hit.point;
                }
            }
            else return new Vector3();
        }

        public void Die()
        {
            anim.SetTrigger(DIE_TRIGGER);
            PlayerDied();
            restartButton.SetActive(true);
        }

        private void PlayerDied()
        {
            isPlayerAlive = false;
        }
    }
}