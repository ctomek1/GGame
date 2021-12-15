using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveNameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveNamerDisplay;

    public void SetDisplay(string waveName)
    {
        waveNamerDisplay.text = waveName;
    }
}
