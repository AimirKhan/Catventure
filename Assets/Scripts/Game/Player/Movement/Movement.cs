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
        [SerializeField] private float speed = .5f;
        [SerializeField] private InputActionReference movement; //TODO Add to Zenject
        
        private void Start()
        {
            Observable.EveryUpdate() // Update stream
                .Where(_ => movement.action.IsPressed()) // Filter on press any Key
                .Select(_ => movement.action.ReadValue<Vector2>()) // Select pressed key
                .Subscribe(MoveObject)
                .AddTo(this); // Link subscribe to GameObject
        }

        private void MoveObject(Vector2 direction)
        {
            var position = transform.position;
            position.x += direction.x * speed * Time.deltaTime;
            position.z += direction.y * speed * Time.deltaTime;
            gameObject.transform.position = position;
        }
    }
}