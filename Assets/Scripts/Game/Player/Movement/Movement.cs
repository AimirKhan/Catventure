using Game.Services;
using Game.World;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Player.Movement
{
    public class Movement : MonoBehaviour
    {
        [Inject] private IPlayerParams playerParams;
        [Inject] private WorldParams worldParams;
        
        [SerializeField] private InputActionReference movement;
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private Vector3 playerVelocity;

        private CharacterController characterController;
        private bool isGroundedPlayer;
        

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            Observable.EveryUpdate() // Update stream
                .Where(_ => !characterController.isGrounded || movement.action.IsPressed()) // Filter on press any movement key
                .Select(_ => movement.action.ReadValue<Vector2>().normalized) // Select pressed values
                .Subscribe(MovementUpdate)
                .AddTo(this); // Link subscribe to GameObject
        }

        private void MovementUpdate(Vector2 direction)
        {
            isGroundedPlayer = characterController.isGrounded;
            VelocityCorrection();
            Move(direction);
            Rotating(direction);
            GravityImpact();
            playerParams.PlayerSpeed.Value = characterController.velocity.magnitude;
        }
        
        private void Move(Vector2 direction)
        {
            var move = new Vector3(direction.x, 0, direction.y);
            characterController.Move(move * playerSpeed * Time.deltaTime);
            playerVelocity.x = characterController.velocity.x;
            playerVelocity.z = characterController.velocity.z;
        }
        
        private void Rotating(Vector2 direction)
        {
            var move = new Vector3(direction.x, 0, direction.y);
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }
        }

        private void GravityImpact()
        {
            playerVelocity.y += worldParams.GravityVelocity * Time.deltaTime;
            characterController.Move(playerVelocity * Time.deltaTime);
        }

        private void VelocityCorrection()
        {
            if (isGroundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0;
            }
        }
    }
}