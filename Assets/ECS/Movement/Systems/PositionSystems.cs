using ECS.Input.Systems;
using ECS.Player;

namespace ECS.Movement.Systems
{
    public class PositionSystems : Feature
    {
        public PositionSystems(Contexts contexts) : base("PositionSystems")
        {
            Add(new PositionSystem(contexts));
            Add(new InputSystem(contexts));
        }
    }
}