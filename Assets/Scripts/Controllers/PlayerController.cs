using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class PlayerController
    {
        App app;
        Health.Health playerHealth;
        public PlayerController(App app, Health.Health player)
        {
            playerHealth = player;
            this.app = app;
            GameModel.OnGameFinished += GameModelOnOnGameFinished;
            playerHealth.OnCharacterDead += GameModelOnOnGameFinished;
        }

        private void GameModelOnOnGameFinished(GameModel obj)
        {
            app.Views.PlayerView.Die();
        }

        private void GameModelOnOnGameFinished()
        {
            app.Views.PlayerView.Die();
        }
    }
}