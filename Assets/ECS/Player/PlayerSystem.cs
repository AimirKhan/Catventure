using JCMG.EntitasRedux;
using UnityEngine;

namespace ECS.Player
{
    public class PlayerSystem : IInitializeSystem
    {
        private readonly GameContext _context;

        public PlayerSystem(Contexts contexts)
        {
            _context = contexts.Game;
        }
        
        public void Initialize()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            if (_context.IsPlayer)
                return;
            var gameObject = new GameObject("Player");
            var player = _context.CreateEntity();
            player.IsPlayer = true;
            player.AddView(gameObject);
            player.AddPosition(Vector3.zero);
            gameObject.Link(player);
        }
    }
}