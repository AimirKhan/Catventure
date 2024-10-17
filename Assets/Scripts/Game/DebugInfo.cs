using Game.Services;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game
{
    public class DebugInfo : MonoBehaviour
    {
        [Inject] private IPlayerParams playerParams;
        [SerializeField] private TextMeshProUGUI currentSpeed;

        private void Start()
        {
            playerParams.PlayerSpeed
                .Subscribe(v => currentSpeed.text = "Current speed: " + v)
                .AddTo(this);
        }
    }
}
