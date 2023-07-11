using System.Collections;
using System.Collections.Generic;
using Catventure;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

public class DebugInfo : MonoBehaviour
{
    [Inject] private IPlayerParams playerParams;
    [SerializeField] private TextMeshProUGUI currentSpeed;
    
    void Start()
    {
        playerParams.PlayerSpeed
            .Subscribe(v => currentSpeed.text = "Current speed: " + v)
            .AddTo(this);
    }
}
