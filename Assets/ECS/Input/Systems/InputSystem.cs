using ECS.Player;
using JCMG.EntitasRedux;
using UnityEngine;

namespace ECS.Input.Systems
{
    public class InputSystem : IInitializeSystem
    {
        readonly InputContext _context;
        private InputControls _inputControls;
        
        public InputSystem(Contexts contexts)
        {
            _context = contexts.Input;
        }

        public void Initialize()
        {
            _inputControls = new InputControls();
            _inputControls.Enable();
            var playerInputSystem = _context.CreateEntity();
            playerInputSystem.AddPlayerInput(_inputControls.PlayerMap);

            var playerInput = new PlayerInputSystem();
            playerInput.SetPlayerMapActions(_inputControls.PlayerMap);
            //playerInputSystem.PlayerInput.value
            //playerInputSystem.PlayerInputSystem.value.SetPlayerMapActions(_inputControls.PlayerMap);
        }
    }
}