using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

namespace Catventure.Input
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private InputActionReference movement;
        [SerializeField] private TextMeshProUGUI debugText;

        private Vector2 movementInput;
        
        private void Start()
        {
            /*
            Observable.EveryUpdate() // Update stream
                .Where(_ => movement.action.IsPressed()) // Filter on press any Key
                .Select(_ => movement.action.) // Select pressed key
                .Subscribe(OnKeyDown)
                .AddTo(this); // Link subscribe to GameObject
             */
        }

        private void Update()
        {
            // IsPressed
            debugText.text = movement.action.IsPressed()
                ? movement.action.ReadValue<Vector2>().ToString()
                : "Nothing pressed";
        }

        private void OnKeyDown(string keyCode)
        {
            switch (keyCode)
            {
                case "w":
                    Debug.Log("keyCode: W");
                    break;
                default:
                    Debug.Log("keyCode: " + keyCode);
                    break;
            }
        }
    }
}