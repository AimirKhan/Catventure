using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using Zenject;

namespace Catventure.Input
{
    public class Movement : MonoBehaviour
    {
        [Inject] private IPlayerParams playerParams;
        
        [SerializeField] private InputActionReference movement;
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private Vector3 playerVelocity;

        private CharacterController characterController;
        private bool isGroundedPlayer;
        private float gravityValue = -9.8f;
        private float gravityScale = 1;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            playerParams.PlayerSpeed.Value = playerSpeed;
            isGroundedPlayer = characterController.isGrounded;
            Observable.EveryUpdate() // Update stream
                .Where(_ => IsPlayerMove() || movement.action.IsPressed()) // Filter on press any Key
                .Select(_ => movement.action.ReadValue<Vector2>()) // Select pressed values
                .Subscribe(MovementUpdate)
                .AddTo(this); // Link subscribe to GameObject
        }

        private void MovementUpdate(Vector2 direction)
        {
            Move(direction);
            Debug.Log("Player is grounded: " + isGroundedPlayer + "velocity " + IsPlayerMove());
            //RotationObject(direction);
            playerSpeed = playerParams.PlayerSpeed.Value;
        }
        
        private void Move(Vector2 direction)
        {
            var move = new Vector3(direction.x, 0, direction.y);
            move.y *= gravityValue;
            characterController.Move(move * playerSpeed * Time.deltaTime);
            if (move != Vector3.zero)
                gameObject.transform.forward = move;
        }
        
        private void RotationObject(Vector2 direction)
        {
            var move = new Vector3(direction.x, 0, direction.y);
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }
        }
        
        private bool IsPlayerMove()
        {
            bool isMove;
            if (isGroundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
                isMove = false;
            }
            else
            {
                isMove = true;
            }
            return isMove;
        }
    }
}