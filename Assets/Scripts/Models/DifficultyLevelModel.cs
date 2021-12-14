using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/DifficultyLevelModel")]
    public class DifficultyLevelModel : ScriptableObject
    {
        [SerializeField]
        private float startingHealth;
        [SerializeField]
        private string difficultyName;
    }
}

