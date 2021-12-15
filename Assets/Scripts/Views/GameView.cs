using System;
using Wave;
using Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Views
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] GameModel gameModel;
        [SerializeField] TimeLeftUI timerToGameOver;
        [SerializeField] KilledEnemiesUI killCounterDisplay;
        [SerializeField] WaveManager waveManager;

        public event Action OnWaveCompleted;

        private int killCounter;

        void Start()
        {
            waveManager.ManageWave();
            gameModel.Init();      
        }

        void Update()
        {
            waveManager.ManageWave();         
            gameModel.Evaluate(Time.deltaTime);
            timerToGameOver.SetTimer((int)gameModel.timeUpTimer);
            killCounterDisplay.SetDisplay(killCounter);
        }
        
        public void OnEnemyKilled()
        {
            gameModel.IncrementTimerOnEnemyKill();
            killCounter++;
        }

        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }       

        
    }
}