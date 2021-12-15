using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/GameModel")]
    public class GameModel : ScriptableObject
    {
        public static event Action<GameModel> OnGameFinished;

        [SerializeField] float timeUp = 5f;
        [SerializeField] float incrementOnKill = 5f;
        [SerializeField] List<WaveModel> waves;

        public float timeUpTimer;

        public List<WaveModel> Waves { get => waves; set => waves = value; }

        public void Init()
        {
            timeUpTimer = timeUp;
        }

        public void Evaluate(float deltaTime)
        {
            EvaluateTimeUp(deltaTime);
        }

        public void IncrementTimerOnEnemyKill()
        {
            timeUpTimer += incrementOnKill;
        }

        void EvaluateTimeUp(float deltaTime)
        {
            timeUpTimer -= deltaTime;

            if (IsTimeOver())
            {
                OnGameFinished?.Invoke(this);
            }
        }

        bool IsTimeOver() => timeUpTimer <= 0;
    }
}