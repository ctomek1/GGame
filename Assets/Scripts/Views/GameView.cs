using System;
using Models;
using UnityEngine;

namespace Views
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] GameModel gameModel;
        [SerializeField] TimeLeftUI timerToGameOver;

        void Start()
        {
            gameModel.Init();
        }

        void Update()
        {
            gameModel.Evaluate(Time.deltaTime);
            timerToGameOver.SetTimer((int)gameModel.timeUpTimer);
        }
    }
}