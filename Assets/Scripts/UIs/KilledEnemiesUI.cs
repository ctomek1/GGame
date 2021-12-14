using System;
using UnityEngine;
using TMPro;

public class KilledEnemiesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCounterDisplay;

    public void SetDisplay(int killCounter)
    {
        killCounterDisplay.text = killCounter.ToString();
    }
}