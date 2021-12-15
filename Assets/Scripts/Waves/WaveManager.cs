using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wave
{
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] GameModel gameModel;
        [SerializeField] ObjectPooler enemiesPooler;
        [SerializeField] WaveNameUI waveNameUI;

        private int waveIndex = 0;
        private int spawnedEnemies;

        public void ManageWave()
        {
            if (CheckIfShouldSpawnAnotherWave())
            {
                SetWaveNameUI();
                for (int i = 0; i < gameModel.Waves[waveIndex].NumberOfEnemies; i++)
                {
                    Poolable poolable = enemiesPooler.Pool.Get();
                    poolable.gameObject.SetActive(true);
                    spawnedEnemies++;
                    poolable.OnPoolableDisabled += DecreaseEnemiesCounter;
                }                
                waveIndex++;               
            }
        }
        private void DecreaseEnemiesCounter(Poolable poolable)
        {
            spawnedEnemies--;
            poolable.OnPoolableDisabled -= DecreaseEnemiesCounter;
        }

        private bool CheckIfShouldSpawnAnotherWave()
        {
            return (spawnedEnemies == 0 && gameModel.Waves[waveIndex] != null);
        }

        private void SetWaveNameUI()
        {
            waveNameUI.SetDisplay(gameModel.Waves[waveIndex].WaveName);
        }
    }
}

