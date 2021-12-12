using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeLeftUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeLeftUI;

    public void SetTimer(int timeLeft)
    {
        timeLeftUI.text = timeLeft.ToString();
    }
}
