using JCMG.EntitasRedux;

namespace ECS.Player
{
    [Input]
    public class PlayerInputComponent : IComponent
    {
        public InputControls.PlayerMapActions value;
    }
}