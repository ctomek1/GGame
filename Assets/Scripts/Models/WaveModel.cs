using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/WaveModel")]
    public class WaveModel : ScriptableObject
    {
        [SerializeField] float numberOfEnemies;
        [SerializeField] string waveName;

        public float NumberOfEnemies { get => numberOfEnemies; set => numberOfEnemies = value; }
        public string WaveName { get => waveName; set => waveName = value; }
    }
}

