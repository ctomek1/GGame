using Models;
using System.Collections.Generic;

namespace Controllers
{
    public class GameController
    {
        List<DifficultyLevelModel> difficulty;
        Health.Health playerHealth;
        App app;

        public GameController(App app)
        {
            this.app = app;
        }
    }
}