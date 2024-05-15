using ECS.Player;

namespace ECS.Views.Systems
{
    public class ViewSystems : Feature
    {
        public ViewSystems(Contexts contexts) : base("ViewSystems")
        {
            //Add(new AddViewSystem(contexts));
            Add(new PlayerSystem(contexts));
        }
    }
}