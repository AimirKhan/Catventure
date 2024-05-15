using UnityEngine;
using UnityEngine.InputSystem;

namespace ECS.Player
{
    public class PlayerInputSystem
    {
        private InputControls.PlayerMapActions _playerMapActions;

        public void SetPlayerMapActions(InputControls.PlayerMapActions playerMapActions)
        {
            _playerMapActions = playerMapActions;
            _playerMapActions.Move.performed += OnMovePerformed;
        }

        private void OnMovePerformed(InputAction.CallbackContext callbackContext)
        {
            Debug.Log("Performed: " + callbackContext.ReadValue<Vector2>());
        }
    }
}