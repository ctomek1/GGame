using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/KillableCharacterModel")]
    public class KillableCharacterModel : ScriptableObject
    {
        [SerializeField] int healthPoints = 10;

        public int HealthPoints { get => healthPoints; }
    }
}